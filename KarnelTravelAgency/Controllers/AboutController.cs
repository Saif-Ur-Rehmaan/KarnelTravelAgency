using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Controllers
{
    public class AboutController : Controller
    {
        private Dictionary<string, Dictionary<string, string>> memberDetails = new Dictionary<string, Dictionary<string, string>>
    {
        {
            "Michel Richard", new Dictionary<string, string>
            {
                { "Name", "Michel Richard" },
                { "Role", "Switzerland Guide" },
                { "Image", "img/team/team_1_2.jpg" },
                { "About", "Compellingly myocardinate resource-leveling testing procedures before multidisciplinary customer service. Enthusiastically monetize intermandated e-tailers whereas 2.0 manufactured products. Rapidiously harness open-source leadership and client-centered niches. Conveniently customize." },
                { "DOB", "May 23, 1987" },
                { "Lives", "Switzerland" },
                { "Email", "michelm@Travon.com" },
                { "Phone", "+163 2254 3654" },
                { "Education", "University of Boxon" }
            }
        },
        {
            "Mishel Marsh", new Dictionary<string, string>
            {
                { "Name", "Mishel Marsh" },
                { "Role", "Switzerland Guide" },
                { "Image", "img/team/team_1_1.jpg" },
                { "About", "Compellingly myocardinate resource-leveling testing procedures before multidisciplinary customer service. Enthusiastically monetize intermandated e-tailers whereas 2.0 manufactured products. Rapidiously harness open-source leadership and client-centered niches. Conveniently customize." },
                { "DOB", "May 23, 1987" },
                { "Lives", "Switzerland" },
                { "Email", "mishelm@Travon.com" },
                { "Phone", "+163 2254 3654" },
                { "Education", "University of Boxon" }
            }
        },
        {
            "Famhida Ruko", new Dictionary<string, string>
            {
                { "Name", "Famhida Ruko" },
                { "Role", "Switzerland Guide" },
                { "Image", "img/team/team_1_2.jpg" },
                { "About", "Compellingly myocardinate resource-leveling testing procedures before multidisciplinary customer service. Enthusiastically monetize intermandated e-tailers whereas 2.0 manufactured products. Rapidiously harness open-source leadership and client-centered niches. Conveniently customize." },
                { "DOB", "May 23, 1987" },
                { "Lives", "Switzerland" },
                { "Email", "famhida@Travon.com" },
                { "Phone", "+163 2254 3654" },
                { "Education", "University of Boxon" }
            }
        },
        {
            "Alex Anfantino", new Dictionary<string, string>
            {
                { "Name", "Alex Anfantino" },
                { "Role", "Switzerland Guide" },
                { "Image", "img/team/team_1_4.jpg" },
                { "About", "Compellingly myocardinate resource-leveling testing procedures before multidisciplinary customer service. Enthusiastically monetize intermandated e-tailers whereas 2.0 manufactured products. Rapidiously harness open-source leadership and client-centered niches. Conveniently customize." },
                { "DOB", "May 23, 1987" },
                { "Lives", "Switzerland" },
                { "Email", "alex@Travon.com" },
                { "Phone", "+163 2254 3654" },
                { "Education", "University of Boxon" }
            }
        },
        {
            "Joseph Carter", new Dictionary<string, string>
            {
                { "Name", "Joseph Carter" },
                { "Role", "Switzerland Guide" },
                { "Image", "img/team/team_1_5.jpg" },
                { "About", "Compellingly myocardinate resource-leveling testing procedures before multidisciplinary customer service. Enthusiastically monetize intermandated e-tailers whereas 2.0 manufactured products. Rapidiously harness open-source leadership and client-centered niches. Conveniently customize." },
                { "DOB", "May 23, 1987" },
                { "Lives", "Switzerland" },
                { "Email", "joseph@Travon.com" },
                { "Phone", "+163 2254 3654" },
                { "Education", "University of Boxon" }
            }
        },
        {
            "David Danial", new Dictionary<string, string>
            {
                { "Name", "David Danial" },
                { "Role", "Switzerland Guide" },
                { "Image", "img/team/team_1_6.jpg" },
                { "About", "Compellingly myocardinate resource-leveling testing procedures before multidisciplinary customer service. Enthusiastically monetize intermandated e-tailers whereas 2.0 manufactured products. Rapidiously harness open-source leadership and client-centered niches. Conveniently customize." },
                { "DOB", "May 23, 1987" },
                { "Lives", "Switzerland" },
                { "Email", "david@Travon.com" },
                { "Phone", "+163 2254 3654" },
                { "Education", "University of Boxon" }
            }
        },
        {
            "Joseph Kariban", new Dictionary<string, string>
            {
                { "Name", "Joseph Kariban" },
                { "Role", "Switzerland Guide" },
                { "Image", "img/team/team_1_7.jpg" },
                { "About", "Compellingly myocardinate resource-leveling testing procedures before multidisciplinary customer service. Enthusiastically monetize intermandated e-tailers whereas 2.0 manufactured products. Rapidiously harness open-source leadership and client-centered niches. Conveniently customize." },
                { "DOB", "May 23, 1987" },
                { "Lives", "Switzerland" },
                { "Email", "josephk@Travon.com" },
                { "Phone", "+163 2254 3654" },
                { "Education", "University of Boxon" }
            }
        },
        {
            "Laniart Carter", new Dictionary<string, string>
            {
                { "Name", "Laniart Carter" },
                { "Role", "Switzerland Guide" },
                { "Image", "img/team/team_1_8.jpg" },
                { "About", "Compellingly myocardinate resource-leveling testing procedures before multidisciplinary customer service. Enthusiastically monetize intermandated e-tailers whereas 2.0 manufactured products. Rapidiously harness open-source leadership and client-centered niches. Conveniently customize." },
                { "DOB", "May 23, 1987" },
                { "Lives", "Switzerland" },
                { "Email", "laniart@Travon.com" },
                { "Phone", "+163 2254 3654" },
                { "Education", "University of Boxon" }
            }
        }
    };


        [Route("/About")]
        public IActionResult AboutUs()
        {
            return View();
        }
        [Route("/About/Team")]
        public IActionResult Team()
        {
            return View();
        }

        [Route("/About/TeamMemberDetail/{MemBerName?}")]
        public IActionResult TeamMemberDetail(string MemBerName)
        {
            if (!string.IsNullOrEmpty(MemBerName))
            {

                var selectedMember = this.memberDetails.FirstOrDefault(member => member.Key == MemBerName);

                if (selectedMember.Key != null)
                {

                    ViewBag.MemberName = selectedMember.Value["Name"];
                    ViewBag.MemberRole = selectedMember.Value["Role"];
                    ViewBag.MemberImage = selectedMember.Value["Image"];
                    ViewBag.MemberAbout = selectedMember.Value["About"];
                    ViewBag.MemberDOB = selectedMember.Value["DOB"];
                    ViewBag.MemberLives = selectedMember.Value["Lives"];
                    ViewBag.MemberEmail = selectedMember.Value["Email"];
                    ViewBag.MemberPhone = selectedMember.Value["Phone"];
                    ViewBag.MemberEducation = selectedMember.Value["Education"];
                }
                else
                {
                    return Redirect("/about/team");
                }
                return View();
            }
            else
            {
                return Redirect("/about/team");
            }


        }
    }
}
