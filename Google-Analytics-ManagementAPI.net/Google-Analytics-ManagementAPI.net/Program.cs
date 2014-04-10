using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Analytics.v3;
using Google.Apis.Analytics.v3.Data;

//Install-Package Google.Apis.Analytics.v3

namespace Google_Analytics_ManagementAPI.net
{
    class Program
    {
        static void Main(string[] args)
        {
        
            string _client_id = "<yourClientID>.apps.googleusercontent.com";
            string _client_secret = "<YourClientSecret>";

            GAAutentication Autentication = new GAAutentication();            
            Autentication.initAnaltyics(_client_id, _client_secret);
            if (Autentication.service == null)
            {
                Console.WriteLine("User declined Autentication. Can not continue/n");
                var name = Console.ReadLine();
            
            } else {
                Program.ListMenu(Autentication);
            }
        }

        public static void ListMenu(GAAutentication Autentication) {

            Console.WriteLine("User Autenticated:  ");
            Console.WriteLine("RefreshToken     :  " + Autentication.credential.Token.RefreshToken);
            Console.WriteLine("Options          :  ");
            Console.WriteLine("     Accounts                                     - Displays a list of user");
            Console.WriteLine("                                                    accounts");
            Console.WriteLine("     wp <Accountid>                               - Displays a list of Web");
            Console.WriteLine("                                                    Properties for an account");
            Console.WriteLine("        Example: wp 45053576");
            Console.WriteLine("     Views <Accountid> <webproprtyid>             - Displays a list of Views");
            Console.WriteLine("                                                    Web Property");
            Console.WriteLine("        Example: views 45053576 UA-45053576-1");
            Console.WriteLine("     Summary                                      - displays a full list");
            Console.WriteLine("     Goals <Accountid> <webproprtyid> <profileid> - List of Goals for a ");
            Console.WriteLine("                                                    view(profile)");
            Console.WriteLine("        Example: views 45053576 UA-45053576-1 78110426");
            Console.WriteLine("     Segments                                     - list of segments the ");
            Console.WriteLine("                                                    user has access to.");
            Console.WriteLine("     Menu                                         - Lists this Menu");
            Console.WriteLine("");

            Program.PromptDoNext(Autentication);        
        }


        public static void readAction(GAAutentication Autentication, string Action) {

         

            string[] vars = Action.Split(' ');

            switch (vars[0].ToLower())
            {
                case "menu":
                    Program.ListMenu(Autentication);
                    break;
                case "accounts":
                    Console.WriteLine("");
                    Console.WriteLine("Listing Accounts:  ");
                    Accounts myAccounts = GAManagement.Accountlist(Autentication.service);
                    if (myAccounts == null)
                    {
                        Console.WriteLine("User does not have access to any Accounts");
                    }
                    else
                    {
                        foreach (Account accnt in myAccounts.Items)
                        {
                            Console.WriteLine(accnt.Name + " - " + accnt.Id);
                        }
                    }
                    Program.PromptDoNext(Autentication);
                    break;
                case "segments":
                    Console.WriteLine("");
                    Console.WriteLine("Listing Segments:  ");
                    Segments mySegments = GAManagement.SegmentList(Autentication.service);
                    foreach (Segment sgmnt in mySegments.Items)
                    {
                        Console.WriteLine(sgmnt.Name + " - " + sgmnt.SegmentId);
                    }

                    Program.PromptDoNext(Autentication);
                    break;
                case "wp":
                    if (vars.Count() < 2)
                    {
                        Console.WriteLine("ERROR: WebProperty list requires an account id: " + vars[0]);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Listing WebProperties for account:  " + vars[1]);
                        Webproperties myWebproperties = GAManagement.Propertieslist(Autentication.service, vars[1]);

                        if (myWebproperties == null)
                        {
                          Console.WriteLine("User does not have access to any Web Properties for:");
                          Console.WriteLine("     Account id:      " + vars[1]);
                        }
                        else
                        {

                            foreach (Webproperty wbprprty in myWebproperties.Items)
                            {
                                Console.WriteLine(wbprprty.Name + " - " + wbprprty.Id);
                            }

                        }
                        Program.PromptDoNext(Autentication);
                    }

                    break;
                case "views":

                    if (vars.Count() < 3)
                    {
                        Console.WriteLine("ERROR: View list requires an account id, and a webproperty id: ");
                        Program.PromptDoNext(Autentication);
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Listing WebProperties for account:  " + vars[1]);
                        Profiles myViews = GAManagement.ProfilesList(Autentication.service, vars[1], vars[2]);


                        if (myViews == null)
                        {
                            Console.WriteLine("User does not have access to any Views for:");
                            Console.WriteLine("     Account id:      " + vars[1]);
                            Console.WriteLine("     Web Property id: " + vars[2]);
                        }
                        else
                        {

                            foreach (Profile vws in myViews.Items)
                            {
                                Console.WriteLine(vws.Name + " - " + vws.Id);
                            }
                        }
                        Program.PromptDoNext(Autentication);
                    }

                    break;
                case "goals":

                    if (vars.Count() < 4)
                    {
                        Console.WriteLine("ERROR: Goal list requires an account id, webproperty id, and a profileid: ");
                        Program.PromptDoNext(Autentication);
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Listing Goals for account:  " + vars[1]);
                        Goals myGoals = GAManagement.GoalList(Autentication.service, vars[1], vars[2], vars[3]);


                        if (myGoals.Items == null)
                        {
                            Console.WriteLine("User does not have access to any Goals for:");
                            Console.WriteLine("    Account id:      " + vars[1]);
                            Console.WriteLine("    Web Property id: " + vars[2]);
                            Console.WriteLine("    Profile id:      " + vars[3]);
                        }
                        else
                        {

                            foreach (Goal gl in myGoals.Items)
                            {
                                Console.WriteLine(gl.Name + " - " + gl.Id);
                            }
                        }
                        Program.PromptDoNext(Autentication);
                    }

                    break;
                case "summary":

                    Console.WriteLine("");
                    Console.WriteLine("Listing Account Summary:  ");
                    AccountSummaries mySummary = GAManagement.AccountSummaryList(Autentication.service);

                    if (mySummary == null)
                    {
                        Console.WriteLine("User does not have access to any Accounts");
                    }
                    else
                    {
                        foreach (AccountSummary sum in mySummary.Items)
                        {
                            Console.WriteLine("Account name: " + sum.Name + " - " + sum.Id);
                            foreach (WebPropertySummary wpsum in sum.WebProperties)
                            {
                                Console.WriteLine("     Web Property: " + wpsum.Name + " - " + wpsum.Id);

                                if (wpsum.Profiles != null)
                                {
                                    foreach (ProfileSummary pfsum in wpsum.Profiles)
                                    {
                                        Console.WriteLine("          Profiles: " + pfsum.Name + " - " + pfsum.Id);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("          No Profiles");

                                }
                            }
                        }
                    }
                    Program.PromptDoNext(Autentication);
                    break;
                default:
                    Console.WriteLine("unknown option: " + vars[0]);
                    Program.PromptDoNext(Autentication);
                    break;
            }      
        
        
        }

        public static void PromptDoNext(GAAutentication Autentication)
        {
            Console.WriteLine("");
            Console.WriteLine("What would you like to do:");
            var Action = Console.ReadLine();
            Program.readAction(Autentication, Action);
        
        
        }


    }
}
