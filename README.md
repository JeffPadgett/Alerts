# Twitch Alert API to Discord and Other Services

## Introduction

This project aims to create a seamless integration between Twitch alerts and various services like Discord. By utilizing webhooks and a simple API, this application will notify you in real-time when events like new followers, subscriptions, and donations occur on your Twitch channel.

## Features

- Real-time notifications for Twitch events.
- Supports multiple services like Discord, Slack, etc.
- Easy to set up and customize.
- Built with .NET Core for high performance and scalability.

## Prerequisites

- .NET Core SDK 3.1 or higher
- A Twitch account with Developer Application registered
- Discord Bot Token (if using Discord)
- Any additional service-specific requirements

## Getting Started

### Setup

1. Clone the repository.

    ```bash
    git clone https://github.com/your-username/twitch-alert-api.git
    ```

2. Navigate to the project directory and restore the packages.

    ```bash
    cd twitch-alert-api
    dotnet restore
    ```

3. Add the necessary environment variables or update the `appsettings.json` file with your credentials.

### Running the Application

```bash
dotnet run
```

### Testing Webhooks

You can use Postman or CURL to test the API endpoints. Example CURL request:

```bash
curl --request POST 'http://localhost:5000/api/alert' \
--header 'Content-Type: application/json' \
--data-raw '{
    "event": "new_follower",
    "username": "new_follower_username"
}'
```

## Usage

- **Twitch to Discord**: To set up notifications for Twitch to Discord, follow the steps in the `docs/twitch-to-discord.md` guide.
- **Twitch to Slack**: To set up notifications for Twitch to Slack, follow the steps in the `docs/twitch-to-slack.md` guide.
- **More services**: Additional guides can be found in the `docs/` directory.

## API Endpoints

- `/api/alert/new_follower` - POST: Trigger a new follower alert
- `/api/alert/new_subscription` - POST: Trigger a new subscription alert
- `/api/alert/new_donation` - POST: Trigger a new donation alert

Detailed API documentation is available at `http://localhost:5000/swagger`.

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on how to contribute to this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## Acknowledgments

- Twitch API documentation
- Discord API documentation
- And many more...

---

Feel free to modify this template to better match the specifics of your project!