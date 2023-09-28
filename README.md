# Twitch Alert API to Discord and Other Services

## Introduction

This project aims to create a seamless integration between Twitch alerts and various services like Discord. By utilizing webhooks and a simple API, this application will notify you in real-time when events like new followers, subscriptions, and donations occur on your Twitch channel.

## Features

- Real-time notifications for Twitch events.
- Supports multiple services like Discord, Slack, etc.
- Easy to set up and customize.
- Built with .NET Core for high performance and scalability.

## Prerequisites

- .NET Core SDK 6 or higher
- A Twitch account with Developer Application registered
- Discord Bot Token (if using Discord)
- Any additional service-specific requirements

## Getting Started

## Usage

- **Twitch to Discord**: To set up notifications for Twitch to Discord, follow the steps in the `docs/twitch-to-discord.md` guide.
- **Twitch to Slack**: To set up notifications for Twitch to Slack, follow the steps in the `docs/twitch-to-slack.md` guide.
- **More services**: Additional guides can be found in the `docs/` directory.

Notes for myself:
This project is uses a CI/CD from azure devops to  templates to generate ARM templates, it generates the core infrastructure resources in a seperate resource group, and then generates it's app sepecific resources. 

Architecture: 

### **1. Core Domain Layers**

- **`Alerts.Core`**:
  - **Domain Layer**: Contains all domain entities, value objects, aggregates, and domain events.
  - **Application Layer**: Contains application services, DTOs, and interfaces for repositories and other infrastructural concerns.
  - **Domain Services**: Operations that don't naturally fit within an entity or value object.

- **`Alerts.Infrastructure`**:
  - Repositories implementations, data access code, and other infrastructural concerns like logging, caching, etc.
  - Configuration for external integrations (e.g., Azure Service Bus, external APIs).
  - Mappings (like Entity to DTO, DTO to Response Model).

### **2. Main Application/API Layers**

- **`Alerts.WebAssembly`**:
  - Your Blazor WebAssembly client.
  - Handles user interfaces, and makes API calls to `Alerts.API`.
  - Integration with Azure AD for user authentication.
  
- **`Alerts.API`**:
  - Main backend API that serves data to the `Alerts.WebAssembly`.
  - Uses Azure AD for user authentication.
  - Offers endpoints to handle user-related functionalities and other data requirements.
  - This is also where users can submit their DiscordPostURL and any other user-specific configurations.

- **`Alerts.EventSub.API`**:
  - Handles webhook events and subscriptions from Twitch.
  - It may send messages to Azure Service Bus, queueing them for processing.
  - It may directly interface with `ChatGPT API` or delegate it to a background service or another module for processing and generating unique messages.

### **3. Additional Services/APIs**

- **`Alerts.DiscordRelay.Service`**:
  - This could be a background service (like a worker service) that listens to Azure Service Bus for new events/messages.
  - Processes the saga using `Workflow Core` (handling the event, generating a message via ChatGPT, and posting to Discord).
  - Uses users' DiscordPostURL for sending messages to Discord.

### **4. Testing**

- **`Alerts.Tests`**:
  - Contains all unit and integration tests.
  - Mocking frameworks can be used to mock dependencies for unit tests.
  - For integration tests, consider using an in-memory database or a test instance of your database.

### **5. Infrastructure as Code (IaC) and CI/CD**

- **Bicep templates** for your Azure resources provisioning.
- **Azure CI/CD pipeline** to automate your build and deployment process.

### **Miscellaneous Tips**:

1. **Bounded Contexts**: If your domain grows, consider breaking your core domain into bounded contexts to better manage and encapsulate different parts of the domain.
   
2. **Anti-Corruption Layer (ACL)**: If you integrate with external systems or third-party services, consider using ACL to translate data between your core domain and the external service.

3. **Azure AD B2C**: Since you mentioned user login via Active Directory, consider Azure AD B2C for user management if you want a more comprehensive solution that supports custom user flows.

4. **Event Sourcing**: Depending on how crucial your events are, and if you want to maintain a history of all changes, you might consider an event-sourced approach.

This architecture provides a starting point and can be refined as you dive deeper into implementation details. Ensure that while following DDD, you focus on the domain and business logic first, letting the infrastructure and other technical details adapt to the needs of the domain.

## twitch docs
https://dev.twitch.tv/docs/eventsub/handling-webhook-events/#verifying-the-event-message

## DevOps
https://dev.azure.com/PadgettDevelopment/Alerts
