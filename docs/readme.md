# MilkCanvas

## Welcome

### Preface
---

Thank you for using MilkCanvas for your interactive tiwtch bot needs <3

MilkCanvas is rolling release. this means that features are addes as they're implemented and tested with integration.

If you experience a bug, please report them! I'm dedicated to fixing bugs and unexpected behaviour in a matter of days, if not hours.

You can [email me](mailto:tristen@tristenhorton.com) or add me on [steam](http://www.steamcommunity.com/id/tristenmilk). Tell me about the bug and ill add it to my priority list immediately!

**Below is a guide for getting started. Below that is a section explaining in detail what every setting does.**

## Getting Started

### Using MilkCanvas
---

MilkCanvas exists in your Notification Tray.

Double clicking the icon will open [Canvas](#canvas).

Alternatively, right clicking the icon will show a menu of additional options to choose from.

### Setting Up Chat Bot
---

If you've already logged into MilkCanvas using your streaming account, you're already half way finished.

By default, chat commands and messages relayed via MilkCanvas will be sent through your main account.

If you don't want this behaviour and have a secondary account specifically for chat bot, check out [Authorizing a Chatbot](#alternate-account-for-chatbot)

### Built-In Commands
---

There are a few builtin commands in the current version of MilkCanvas. Click each one for details on the commands and how to use them.

- [!uptime](#uptime)
- [!commands](#commands)
- [!command](#command)
- [!alias](#alias)
- [!permission](#permission)
- [!bookmark](#bookmark)

## Canvas

Canvas is similar to a settings or preferences menu. The following are all of the options available in Canvas and the nuances of each option.

### Alternate Account for Chatbot

Toggle this checkbox on if you want to use another account for the chatbot.

Adjacent to the checkbox is a Twitch Connect button. Click this button to be taken to a new page to authorize your alternate account.

**IMPORTANT: Log out of your main twitch account in your web browser. It will automatically authorize your main twitch account if you're still logged into it.**

## Built-in Commands

Here are all of the immediately available built-in command in the latest version of MilkCanvas. 

### Uptime
---

```
!uptime - Prints the current uptime of the stream, if the stream is live.
```

### Commands
---

```
!commands - Prints a list of all of the available commands.
```

### Command
---

```
!command - Creates, deletes, or updates chat commands.

Usage: !command [set|clear] [command] [set:message ...]

Examples:

!command set social Check me out on facebook! facebook.com/somepath
!command clear social
```

### Alias
---

```
!alias - Creates or removes aliases for existing commands.

Usage: !alias [set|clear] [alias] [command]

Examples:

This will let us use !s instead of !social:
!alias set s social

To remove the alias:
!alias clear s
```

### Permission
---

```
!permission - Changes the permissions required to run a command.

Usage: !permission [command] [host|mod|sub|all]

Broadcaster/Channel Owner only:
!permission social host

Moderators and Broadcaster only:
!permission social mod

Subscribers, Moderators and Broadcaster only:
!permission social sub

Everyone:
!permission social all
```

### Bookmark
---

```
!bookmark - Flags the current timestamp in the stream and saves it.

Usage: !bookmark (description)
```

**Details**

This command will save a timestamp along with the time that the stream started in a bookmarks file. You can export bookmarks in [Canvas](#canvas).