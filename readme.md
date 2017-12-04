# MilkCanvas 

# Welcome

Thank you for using MilkCanvas for your interactive tiwtch bot needs <3 

MilkCanvas is rolling release. this means that features are addes as they're implemented and tested with integration. 
 
If you experience a bug, please report them! I'm dedicated to fixing bugs and unexpected behaviour in a matter of days, if not hours. 
 
You can [email me](mailto:tristen@tristenhorton.com) or add me on [steam](http://www.steamcommunity.com/id/tristenmilk). Tell me about the bug and ill add it to my priority list immediately! 
 
**Below is a guide for getting started. Below that is a section explaining in detail what every setting does.** 
 
# Getting Started 
 
## Using MilkCanvas 
 
MilkCanvas exists in your Notification Tray. 
 
Double clicking the icon will open [Canvas](#canvas). 
 
Alternatively, right clicking the icon will show a menu of additional options to choose from. 
 
## Setting Up Chat Bot 
 
If you've already logged into MilkCanvas using your streaming account, you're already half way finished. 
 
By default, chat commands and messages relayed via MilkCanvas will be sent through your main account. 
 
If you don't want this behaviour and have a secondary account specifically for chat bot, check out [Alternate Account for Chatbot](#alternate-account-for-chatbot) 
 
## Built-In Commands
 
There are a few builtin commands in the current version of MilkCanvas. Click each one for details on the commands and how to use them. 
 
- [!uptime](#uptime) 
- [!commands](#commands) 
- [!command](#command) 
- [!alias](#alias) 
- [!permission](#permission) 
- [!bookmark](#bookmark) 
 
# Canvas 

> Canvas is similar to a settings or preferences menu. The following are all of the options available in Canvas and the nuances of each option. 

## General Settings 
 
### Alternate Account for Chatbot 
 
> Toggle this checkbox on if you want to use another account for the chatbot. 
>
> Adjacent to the checkbox is a Twitch Connect button. Click this button to be taken to a new page to authorize your alternate account. 
>
> **IMPORTANT: Log out of your main twitch account in your web browser. It will automatically authorize your main twitch account if you're still logged into it.**
 
### Relay Message After a New Subscription 
 
> Toggle this checkbox and fill in the text box below with a message to relay every time you get a new subscriber. Messages are relayed in chat by the Chatbot. 
>
> There are some variables you can use here, too. 
>  
> ``` 
> {subscriber} - returns the name of the new subscriber. 
>  
> {tier} - returns Twitch Prime, $4.99, $14.99, or $24.99. 
>  
> {emote} - returns a random emote from the channel's emote set. 
>  
> {emote#} - replace # with a number greater than 0. returns a random emote from the channel's emote set for each number. Numbers that are reused will use the same emote each time.  
> ``` 
 
### Relay Message After a Resubscription 
 
> Toggle this checkbox and fill in the text box below with a message to relay every time you get a resubscriber. Messages are relayed in chat by the selected Chatbot. 
>  
> There are some variables you can use here, too. 
>  
> ``` 
> {resubscriber} - returns the name of the resubscriber. 
>  
> {length} - returns the number of months the user has been subbed. 
>  
> {tier} - returns Twitch Prime, $4.99, $14.99, or $24.99. 
>  
> {emote} - returns a random emote from the channel's emote set. 
>  
> {emote#} - replace # with a number greater than 0. returns a random emote from the channel's emote set for each number. Numbers that are reused will use the same emote each time.  
> ``` 
 
### Relay Message After a Gifted Subscription 
 
> ***This feature is not live yet.*** 
>
> Toggle this checkbox and fill in the text box below with a message to relay every time you get a gifted subscriber. Messages are relayed in chat by the selected Chatbot. 
 
### Timeout Commands to Prevent Spam 
 
> Toggle this checkbox and change the numeric counter below to the number of seconds you'd like commands to be delayed in their next useage. 
 
### Reconnect MilkCanvas if Connection is Lost 
 
> Toggle this checkbox and change the numeric counter below to the number of seconds you'd like MilkCanvas to wait before retrying to connect. 
> 
> **10 seconds is the recommended delay.** 

## Tagging and Mentions

### Tag Users Who Call Commands

> Only certain commands utilize this feature.
>
> Enabling this will inform the chatbot to @Tag the person who used the command.

### Moderators Can Pseudo Tag Users

> Enabling this will allow moderators to tell the chatbot who should be tagged.
> 
> Example usage
> 
> ```
> !uptime @otherPerson
> !commands @otherPerson
> ```

## Permissions

### Exempt Moderators From Command Delay

> Moderators are not affected by command delays if this is enabled.

### Moderators Can Set Chat Commands

> Moderators have the ability to modify existing chat commands and create new chat commands if this is enabled.

### Moderators Can Remove Chat Commands

> Moderators have the ability to remove existing chat commands if this is enabled.

### Moderators Can Set Aliases

> Moderators have the ability to modify existing aliases and create new aliases if this is enabled.

### Moderators Can Remove Aliases

> Moderators have the ability to remove aliases if this is enabled.
 
# Built-in Commands Extended
 
> Here are all of the immediately available built-in command in the latest version of MilkCanvas.  
 
## Uptime 

> Prints the current uptime of the stream, if the stream is live. 
> 
> ```
> usage: !uptime
> ```
 
## Commands 
 
> Prints a list of all of the available commands. 
> 
> ```
> usage: !commands
> ```
 
## Command 
 
> Creates, deletes, or updates chat commands. 
> 
> ``` 
> Usage: !command [set|clear] [command] [set:message ...] 
>  
> Examples: 
>  
> !command set social Check me out on facebook! facebook.com/somepath 
> !command clear social 
> ``` 
 
## Alias 
 
> Creates or removes aliases for existing commands. 
> 
> ```
> Usage: !alias [set|clear] [alias] [command] 
> 
> Examples: 
> 
> This will let us use !s instead of !social: 
> !alias set s social 
> 
> To remove the alias: 
> !alias clear s 
> ``` 
 
## Permission 
 
> Changes the permissions required to run a command. 
>
> ```
> Usage: !permission [command] [host|mod|sub|all] 
>
> Broadcaster/Channel Owner only: 
> !permission social host 
>
> Moderators and Broadcaster only: 
> !permission social mod 
>
> Subscribers, Moderators and Broadcaster only: 
> !permission social sub 
>
> Everyone: 
> !permission social all 
> ``` 
 
## Bookmark 
 
> !bookmark - Flags the current timestamp in the stream and saves it. 
>
> ``` 
> Usage: !bookmark (description) 
> ``` 
>
> Bookmarks are saved in separate files in the Bookmarks folder. The title of each file is the description of the bookmark, limited to 32 characters. This is the information within each file:
>
> - The description of the bookmark.
> - The date the bookmark was made.
> - The Uptime since the stream started. This can be used to deduce the stream date if the stream started on a different day.
>
> Bookmarks cannot be made within 15 seconds of eachother; bookmarks made by the broadcaster ignore this delay. Moderators are not ignored unless the are [exempted.](#Exempt-Moderators-From-Command-Delay)