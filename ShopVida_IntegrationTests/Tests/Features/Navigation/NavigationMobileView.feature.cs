// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ShopVidaTests.Tests.Features.Navigation
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("NavigationMobileView")]
    public partial class NavigationMobileViewFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "NavigationMobileView.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "NavigationMobileView", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
#line 4
 testRunner.When("User input specific dimensions for \"Pixel2XL\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "email",
                        "password",
                        "buttonName",
                        "landedScreenName"});
            table14.AddRow(new string[] {
                        "testaccount@gmail.com",
                        "Test@1234",
                        "LOG IN",
                        "Products"});
#line 5
 testRunner.And("I should already logged in with credentials", ((string)(null)), table14, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate main menu navigation links mobile view")]
        [NUnit.Framework.TestCaseAttribute("Create New Product", "", "Design", null)]
        [NUnit.Framework.TestCaseAttribute("Marketing Tools", "Email Marketing Tool", "EmailMarketing", null)]
        [NUnit.Framework.TestCaseAttribute("Sales", "Sales Dashboard", "Dashboard", null)]
        [NUnit.Framework.TestCaseAttribute("Account", "Account Settings", "Settings", null)]
        [NUnit.Framework.TestCaseAttribute("Design Gallery", "", "DesignGallery", null)]
        [NUnit.Framework.TestCaseAttribute("Learn More about VIDA", "", "LearnMoreAboutVIDA", null)]
        [NUnit.Framework.TestCaseAttribute("Give Us Feedback", "", "Feedback", null)]
        public virtual void ValidateMainMenuNavigationLinksMobileView(string menu, string submenu, string page, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate main menu navigation links mobile view", null, exampleTags);
#line 9
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 10
 testRunner.When(string.Format("I click \"{0}\" and \"{1}\"", menu, submenu), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.Then(string.Format("I navigated on page \"{0}\"", page), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify main menu navigation links mobile view")]
        [NUnit.Framework.TestCaseAttribute("Marketing Tools", "Editorial Photography", "EditorialPhotography", null)]
        [NUnit.Framework.TestCaseAttribute("Marketing Tools", "Premium Subscription", "PremiumSubscription", null)]
        [NUnit.Framework.TestCaseAttribute("Marketing Tools", "Artist Ambassador Program", "ArtistAmbassadorProgram", null)]
        [NUnit.Framework.TestCaseAttribute("Marketing Tools", "Tips & Resources", "TipsAndResources", null)]
        [NUnit.Framework.TestCaseAttribute("Account", "Order History", "OrderHistory", null)]
        [NUnit.Framework.TestCaseAttribute("Help Center", "", "HelpCenter", null)]
        public virtual void VerifyMainMenuNavigationLinksMobileView(string menu, string submenu, string page, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify main menu navigation links mobile view", null, exampleTags);
#line 23
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 24
 testRunner.When(string.Format("I click \"{0}\" and \"{1}\"", menu, submenu), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.Then(string.Format("I am on the page \"{0}\"", page), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify social media icons navigation mobile view")]
        [NUnit.Framework.CategoryAttribute("Regression")]
        [NUnit.Framework.TestCaseAttribute("twitter", "Twitter", null)]
        [NUnit.Framework.TestCaseAttribute("facebook", "Facebook", null)]
        [NUnit.Framework.TestCaseAttribute("instagram", "Instagram", null)]
        [NUnit.Framework.TestCaseAttribute("pinterest", "Pinterest", null)]
        [NUnit.Framework.TestCaseAttribute("youtube", "YouTube", null)]
        public virtual void VerifySocialMediaIconsNavigationMobileView(string icon, string page, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify social media icons navigation mobile view", null, @__tags);
#line 37
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 38
 testRunner.When(string.Format("I click \"{0}\" social media icon", icon), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.Then(string.Format("I am on the page \"{0}\"", page), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify About list items navigation on lower footer mobile view")]
        [NUnit.Framework.CategoryAttribute("Regression")]
        [NUnit.Framework.TestCaseAttribute("Artist Ambassador Program", "ArtistAmbassadorProgram", null)]
        [NUnit.Framework.TestCaseAttribute("Become a Premium Member", "PremiumSubscription", null)]
        [NUnit.Framework.TestCaseAttribute("Shipping Times", "ShippingTimes", null)]
        [NUnit.Framework.TestCaseAttribute("Artist Terms & Conditions", "TermsAndConditions", null)]
        [NUnit.Framework.TestCaseAttribute("VIDA Reviews", "Reviews", null)]
        [NUnit.Framework.TestCaseAttribute("VIDA Blog", "Blogs", null)]
        public virtual void VerifyAboutListItemsNavigationOnLowerFooterMobileView(string listItem, string page, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify About list items navigation on lower footer mobile view", null, @__tags);
#line 50
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 51
 testRunner.When(string.Format("I click \"{0}\" lower footer link", listItem), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
 testRunner.Then(string.Format("I am on the page \"{0}\"", page), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify Privacy Policy navigation on lower footer mobile view")]
        [NUnit.Framework.CategoryAttribute("Regression")]
        [NUnit.Framework.TestCaseAttribute("Privacy Policy", "PrivacyPolicy", null)]
        public virtual void VerifyPrivacyPolicyNavigationOnLowerFooterMobileView(string listItem, string page, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Privacy Policy navigation on lower footer mobile view", null, @__tags);
#line 64
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 3
this.FeatureBackground();
#line 65
 testRunner.When(string.Format("I click \"{0}\" lower footer link", listItem), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
 testRunner.Then(string.Format("I navigated on page \"{0}\"", page), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
