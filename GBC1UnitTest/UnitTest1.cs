using System;
using System.Windows.Controls;
using Claims;
using GBChallenge1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Menu = GBChallenge1.Menu;

namespace GBC1UnitTest
{
    [TestClass]
    public class UnitTest1
    {
       
        [TestMethod]
        public void addingToCafeTest()
        {
            //Create a Test Project for your repository methods. (You don't need to test your constructors or objects, just your methods)
            /*            StreamingContent content = new StreamingContent();
            content.Title = "Mad Max: Fury Road";

            StreamingContentRepository repo = new StreamingContentRepository();
            bool wasAdded = repo.AddContentToDirectory(content);
            Assert.IsTrue(wasAdded);*/
            GBChallenge1.Menu cafeTest = new Menu();
            cafeTest.Name = "Spaghetti";

            menuRepository repo = new menuRepository();
            bool wasAdded = repo.AddItemToDirecotry(cafeTest);
            Assert.IsTrue(wasAdded);


        }
        [TestMethod]
        public void addingToClaims()
        {
            //3. Create a Test Class for your repository methods.
            ClaimsType claimsTest = new ClaimsType();
            claimsTest.ClaimID = 45;

            claimsRepository repo = new claimsRepository();
            bool wasAdded = repo.AddClaimToDirecotry(claimsTest);
            Assert.IsTrue(wasAdded);



        }
    }
}
