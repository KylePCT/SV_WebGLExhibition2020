using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class URLLoader : MonoBehaviour
{
    //Can't call a public string url here because it doesnt like it, so needs a different call for each URL.
    public void OpenSonovisionHomeURL()
    {
        Application.ExternalEval("window.open(\"https://www.sonovision.co.uk\",\"_blank\")");
        //Application.ExternalEval("window.open(\"http://www.unity3d.com\",\"_blank\")");
    }

    public void OpenSonovisionAboutURL()
    {
        Application.ExternalEval("window.open(\"https://www.sonovision.co.uk/about.html\",\"_blank\")");
    }

    public void OpenSonovisionRecruitmentURL()
    {
        Application.ExternalEval("window.open(\"https://www.sonovision.co.uk/recruit.html\",\"_blank\")");
    }

    public void OpenSonovisionContactURL()
    {
        Application.ExternalEval("window.open(\"https://www.sonovision.co.uk/contact.html\",\"_blank\")");
    }

    public void OpenSonovisionSectorsURL()
    {
        Application.ExternalEval("window.open(\"https://www.sonovision.co.uk/pages-sectors.html\",\"_blank\")");
    }

    public void OpenSonovisionTechPubURL()
    {
        Application.ExternalEval("window.open(\"https://www.sonovision.co.uk/services-Tech-Pubs.html\",\"_blank\")");
    }

    public void OpenSonovisionStudioURL()
    {
        Application.ExternalEval("window.open(\"https://www.sonovision.co.uk/services-Studio.html\",\"_blank\")");
    }

    public void OpenSonovisionSupportURL()
    {
        Application.ExternalEval("window.open(\"https://www.sonovision.co.uk/services-Support.html\",\"_blank\")");
    }

    public void OpenSonovisionPortfolioURL()
    {
        Application.ExternalEval("window.open(\"https://www.sonovision.co.uk/portfolio-Home.html\",\"_blank\")");
    }

    public void OpenOrtecHomeURL()
    {
        Application.ExternalEval("window.open(\"https://www.ortec-group.com\",\"_blank\")");
    }

    public void OpenTestPDF()
    {
        Application.ExternalEval("window.open(\"https://www.sonovision.co.uk/unity/test.pdf\",\"_blank\")");
    }
}