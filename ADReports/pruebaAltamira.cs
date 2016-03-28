using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices.Protocols;
using System.Security.Permissions;
using System.Net;

namespace ADReports
{
    class pruebaAltamira
    {
        public static void lol()
        {
            //DirectoryEntry de = new DirectoryEntry("10.225.171.210:32768","","",AuthenticationTypes.Anonymous);



            LdapConnection ldap = new LdapConnection("camtgsg1:32768");
            ldap.AuthType = AuthType.Anonymous;
            //ldap.Credential = credential;

            SearchRequest sr = new SearchRequest("ou=Personas,ou=Entidades Corporativas,ou=TMG,o=Telefonica,c=GU", "(objectclass=*)", SearchScope.Subtree, "*");
            SearchResponse s = (SearchResponse) ldap.SendRequest(sr);
            

            foreach (SearchResultEntry i in s.Entries)
            {
                Console.WriteLine(i.Attributes["cn"][0]);
            }
        }
    }
}
