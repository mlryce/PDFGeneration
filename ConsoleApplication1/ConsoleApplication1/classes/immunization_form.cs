using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.classes
{
    public class immunization_form
    {
        public static organization asdf;
        public string treatment_consent_text;
        

        public immunization_form(organization qwer)
        {
            asdf = qwer;
            treatment_consent_text = "Medical Treatment Consent (For Student Under 18): I hereby authorize " + qwer.get_organization_name() + " diagnostic procedures and to " +
                                     "render any treatment or medical, surgial, pyschological or psychiatric care deemed necessary to the health and well-being of my child.  I grant " +
                                     "permission for the transfer of my child to an accredited hospital or other health care facility if deemed necessary by the medical or mental " +
                                     "health provider.";
        }


    }
    

}

