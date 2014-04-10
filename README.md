GoogleAnaltyicsManagmentAPIDotNet
=================================

Sample project for working with the Google Analytics Management API in C# .net

This is a simple console application:

The menu allows for the following:

List Accounts             -  Lists all of the accounts for the authenticated user.

List Web Properties   - Lists all of the Web properties for an account for the authenticated user.

List Views (profiles)    - Lists all of the Views (profiles) for a Web property and account for the authenticated user.

Account summary     - A summary list of all Accounts, web properties, and views(profiles) for the authenticated user.


SETUP
=================================
You will need to create your own credentials in the Google Apis console for it to work:
Go to :  https://console.developers.google.com

Create a new Application:  

APIs & Auth -> APIs Enable Google Analytics API

APIs & Auth -> Credentials -> Create client id for Native application
               it is here you will find the Client id and client secret you will need in order to run the project.
               
APIs & Auth -> Consent screen
                 Be sure to supply an Email Address, and product name. 


Note:  This Project only Selects from the management API.  
