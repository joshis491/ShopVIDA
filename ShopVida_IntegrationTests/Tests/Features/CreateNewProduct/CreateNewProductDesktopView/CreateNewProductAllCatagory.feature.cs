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
namespace ShopVidaTests.Tests.Features.CreateNewProduct.CreateNewProductDesktopView
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CreateNewProductAllCatagory")]
    public partial class CreateNewProductAllCatagoryFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CreateNewProductAllCatagory.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CreateNewProductAllCatagory", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create new product for all catagories")]
        [NUnit.Framework.CategoryAttribute("ENG-544")]
        [NUnit.Framework.TestCaseAttribute("scarves", "Cotton", "Natural Cotton Scarf", "Natural Cotton Scarf", null)]
        [NUnit.Framework.TestCaseAttribute("scarves", "Silk", "Mini Square Scarf", "Mini Square Scarf", null)]
        [NUnit.Framework.TestCaseAttribute("scarves", "Merino Wool", "Oversized Merino Wool", "Oversized Merino Wool", null)]
        [NUnit.Framework.TestCaseAttribute("scarves", "Cashmere", "100% Cashmere Scarf", "100% Cashmere Scarf", null)]
        [NUnit.Framework.TestCaseAttribute("scarves", "Infinity", "Infinity Eco Scarf", "Infinity Eco Scarf", null)]
        [NUnit.Framework.TestCaseAttribute("scarves", "Infinity", "Natural Cotton Scarf", "Natural Cotton Scarf", null)]
        [NUnit.Framework.TestCaseAttribute("bags", "Studio Bag", "Studio Bag", "Studio Bag", null)]
        [NUnit.Framework.TestCaseAttribute("bags", "Handbags", "Statement Bag", "Statement Bag", null)]
        [NUnit.Framework.TestCaseAttribute("bags", "Handbags", "Tote Bag", "Tote Bag", null)]
        [NUnit.Framework.TestCaseAttribute("bags", "Handbags", "Studio Bag", "Studio Bag", null)]
        [NUnit.Framework.TestCaseAttribute("bags", "Clutches", "Leather Statement Clutch", "Leather Statement Clutch", null)]
        [NUnit.Framework.TestCaseAttribute("bags", "Clutches", "Statement Clutch", "Statement Clutch", null)]
        [NUnit.Framework.TestCaseAttribute("bags", "Pouches", "Foldaway Tote", "Foldaway Tote", null)]
        [NUnit.Framework.TestCaseAttribute("bags", "Pouches", "Carry-All Pouch", "Carry-All Pouch", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Tees", "Modern Tee", "Modern Tee", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Tees", "Unisex Tee - Front Print", "Unisex Tee - Front Print", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Tops", "Modern Eco Sweatshirt", "Modern Eco Sweatshirt", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Tops", "Essential Top", "Essential Top", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Tops", "Sleeveless Top", "Sleeveless Top", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Leggings", "Leggings", "Leggings", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Wraps", "Sheer Wrap", "Sheer Wrap", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Wraps", "Cocoon Wrap", "Cocoon Wrap", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Wraps", "Wool Poncho Wrap", "Wool Poncho Wrap", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Athleisure", "Modern Eco Sweatshirt", "Modern Eco Sweatshirt", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Athleisure", "Infinity Eco Scarf", "Infinity Eco Scarf", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Athleisure", "Leggings", "Leggings", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Athleisure", "Yoga Mat", "Yoga Mat", null)]
        [NUnit.Framework.TestCaseAttribute("accessories", "Active", "Water Bottle", "Water Bottle", null)]
        [NUnit.Framework.TestCaseAttribute("accessories", "Active", "Yoga Mat", "Yoga Mat", null)]
        [NUnit.Framework.TestCaseAttribute("accessories", "Active", "Studio Bag", "Studio Bag", null)]
        [NUnit.Framework.TestCaseAttribute("accessories", "Umbrellas", "Foldable Umbrella", "Foldable Umbrella", null)]
        [NUnit.Framework.TestCaseAttribute("accessories", "Travel + Tech", "Leather Accent Tag", "Leather Accent Tag", null)]
        [NUnit.Framework.TestCaseAttribute("accessories", "Travel + Tech", "Leather Passport Case", "Leather Passport Case", null)]
        [NUnit.Framework.TestCaseAttribute("accessories", "Wallets", "Leather Slimfold Wallet", "Leather Slimfold Wallet", null)]
        [NUnit.Framework.TestCaseAttribute("accessories", "Wallets", "Leather Zip-Around Wallet", "Leather Zip-Around Wallet", null)]
        [NUnit.Framework.TestCaseAttribute("accessories", "Jewelry", "Round Statement Ring", "Round Statement Ring", null)]
        [NUnit.Framework.TestCaseAttribute("accessories", "Jewelry", "Oversized Round Pendant", "Oversized Round Pendant", null)]
        [NUnit.Framework.TestCaseAttribute("accessories", "Jewelry", "Oversized Square Pendant", "Oversized Square Pendant", null)]
        [NUnit.Framework.TestCaseAttribute("accessories", "Jewelry", "Oversized Statement Pendant", "Oversized Statement Pendant", null)]
        [NUnit.Framework.TestCaseAttribute("accessories", "Men\'s", "Men\'s Cotton Pocket Square", "Men\'s Cotton Pocket Square", null)]
        [NUnit.Framework.TestCaseAttribute("accessories", "Men\'s", "Men\'s Silk Pocket Square", "Men\'s Silk Pocket Square", null)]
        [NUnit.Framework.TestCaseAttribute("accessories", "Men\'s", "Tie", "Tie", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Pillows", "Square Pillow", "Square Pillow", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Pillows", "Oblong Pillow", "Oblong Pillow", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Kitchen & Dining", "Water Bottle", "Water Bottle", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Kitchen & Dining", "Classic Mug", "Classic Mug", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Kitchen & Dining", "Tea Towel Set of 2", "Tea Towel Set of 2", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Kitchen & Dining", "Statement Mug", "Statement Mug", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Kitchen & Dining", "Bamboo Coaster Set - Single Artwork", "Bamboo Coaster Set - Single Artwork", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Kitchen & Dining", "Bamboo Coaster Set - Mixed Artwork", "Bamboo Coaster Set - Mixed Artwork", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Kitchen & Dining", "Table Runner", "Table Runner", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Home Decor", "Ornament", "Ornament", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Stationery", "Leather Journal", "Leather Journal", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Stationery", "Greeting Cards Set", "Greeting Cards Set", null)]
        [NUnit.Framework.TestCaseAttribute("scarves", "Modal", "Modal Scarves", "100% Modal", null)]
        [NUnit.Framework.TestCaseAttribute("scarves", "Silk", "Cashmere Silk Scarf", "Cashmere Silk", null)]
        [NUnit.Framework.TestCaseAttribute("scarves", "Silk", "Silk Square Scarf", "Silk Square", null)]
        [NUnit.Framework.TestCaseAttribute("accessories", "Jewelry", "Charm Bracelet", "Square Beveled Charm Bracelet", null)]
        [NUnit.Framework.TestCaseAttribute("accessories", "Travel + Tech", "iPhone Case", "Iphone Cover", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Tees", "Boatneck Boyfriend Tee", "Boatneck Boyfriend Tee", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Tees", "Unisex Tee - Full Print", "Unisex Tee - Print All-over", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Tops", "Printed Racerback Top", "Racerback", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Tops", "Sleeveless Knit", "Sleeveless Knit Top", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Tops", "Women\'s Crewneck Sweatshirt", "Sweatshirt", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Leggings", "Yoga Capri Pants", "Capri", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Athleisure", "Yoga Capri Pants", "Capri", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Athleisure", "Printed Racerback Top", "Racerback", null)]
        [NUnit.Framework.TestCaseAttribute("apparel", "Athleisure", "Women\'s Crewneck Sweatshirt", "Sweatshirt", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Kitchen & Dining", "Oven Mitt & Potholder", "Oven Mitt Potholder", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Kitchen & Dining", "Oblong Glass Tray", "Glass Tray - Oblong", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Kitchen & Dining", "Square Glass Tray", "Glass Tray - Square", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Kitchen & Dining", "Round Glass Tray", "Glass Tray - Round", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Kitchen & Dining", "Placemat Set", "Placemat Set Round", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Kitchen & Dining", "Placemat Set", "Placemat Set Rectangle", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Kitchen & Dining", "Napkin Set", "Napkins", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Home Decor", "Wood Wall Art - 8x24", "Wood 8x24", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Home Decor", "Wood Wall Art - Set of 3", "Wood Wall Art 8x24 Set of 3", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Home Decor", "Wood Wall Art - 12x12", "Wood Wall Art 12x12", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Home Decor", "Wood Wall Art - Set of 4", "Wood Wall Art Set of 4", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Home Decor", "Wood Wall Art - 30x20", "Wood Wall Art 30x20", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Home Decor", "Square Glass Tray", "Glass Tray - Square", null)]
        [NUnit.Framework.TestCaseAttribute("scarves", "Cashmere", "Cashmere Silk Scarf", "Cashmere Silk", null)]
        [NUnit.Framework.TestCaseAttribute("home", "Home Decor", "Round Glass Tray", "Glass Tray - Round", null)]
        public virtual void CreateNewProductForAllCatagories(string category, string product, string shopifyProductType, string shopvidaProductType, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ENG-544"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create new product for all catagories", null, @__tags);
#line 4
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "email",
                        "password",
                        "buttonName",
                        "landedScreenName"});
            table4.AddRow(new string[] {
                        "testaccount@gmail.com",
                        "Test@1234",
                        "LOG IN",
                        "Products"});
#line 5
 testRunner.Given("I should already logged in with credentials", ((string)(null)), table4, "Given ");
#line 8
 testRunner.When("I select \"Create New Product\" menu with \"\" submenu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.Then("I should be navigated to \"Design\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
 testRunner.When(string.Format("I select \"{0}\" product category type with \"{1}\" sub category type", category, product), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.And(string.Format("Verify product subcategory page title should be \"{0}\"", product), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And(string.Format("I select \"{0}\" subcategory type", shopifyProductType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.Then("I navigated to a page where side bar header should be \"Design Your Product\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.And("Verify active navigation tab text should be \"DESIGN\" or \"01\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("Verify \"Preview\" button should be disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("Verify \"Launch Product\" button should be disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.When("I click on product info", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then(string.Format("Verify subcategory type below side bar header should be \"{0}\"", shopvidaProductType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
 testRunner.And("I set my retail price for product is \"100\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.When("I Click on \"Choose From Gallery\" Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
 testRunner.And("I select \"Artwork1\" artwork", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.Then("Verify \"Launch Product\" button should be enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
 testRunner.Then("Verify \"Preview\" button should be enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
 testRunner.When("I Click on \"Preview\" Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.And("Preview the all images", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.When("I Click on \"Launch Product\" Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
 testRunner.Then("I should be navigated to \"Launch\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
 testRunner.And("Verify active navigation tab text should be \"LAUNCH\" or \"02\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("Verify product is live text on launch page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.When("I Click on \"Skip\" Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
 testRunner.And("Verify active navigation tab text should be \"SAMPLE\" or \"03\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.Then("I should be navigated to \"Sample\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
 testRunner.Then("Verify page heading name should be \"Shopping Bag\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
 testRunner.When("I click Remove Samples button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
 testRunner.When("I am on the page \"Home\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
 testRunner.Then(string.Format("Verify product card is shown for \"Artwork1\" with \"{0}\" subcategory", shopvidaProductType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
 testRunner.And(string.Format("Remove the product from home page for \"Artwork1\" with \"{0}\" subcategory", shopvidaProductType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And(string.Format("Verify product card is not shown for \"Artwork1\" with \"{0}\" subcategory", shopvidaProductType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
