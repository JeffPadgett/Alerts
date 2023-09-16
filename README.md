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

## twitch docs
https://dev.twitch.tv/docs/eventsub/handling-webhook-events/#verifying-the-event-message

## DevOps
https://dev.azure.com/PadgettDevelopment/Alerts
