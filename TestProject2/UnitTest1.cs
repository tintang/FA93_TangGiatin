using System;
using Bruchrechner;
using NUnit.Framework;

namespace TestProject2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestValidBruch()
        {
            var bruch = new Bruch(8, 4);
        }

        [Test]
        public void TestInvalidBruch()
        {
            Assert.Throws<ArgumentException>(() => new Bruch(9, 0));
        }

        [Test]
        public void KuerzeUngekuerztenBruch()
        {
            var bruch = new Bruch(4, 8);
            bruch.Kuerze();
            Assert.AreEqual(1, bruch.Zaehler);
            Assert.AreEqual(2, bruch.Nenner);
        }

        [Test]
        public void KuerzeGekuerztenBruch()
        {
            var bruch = new Bruch(1, 2);
            bruch.Kuerze();
            Assert.AreEqual(1, bruch.Zaehler);
            Assert.AreEqual(2, bruch.Nenner);
        }

        [Test]
        public void MultipliziereMitNull()
        {
            var bruch1 = new Bruch(1, 2);
            Assert.Throws<ArgumentException>(() => bruch1.MultipliziereMit(null));
        }

        [Test]
        public void MultipliziereMit()
        {
            var bruch1 = new Bruch(1, 2);
            var bruch2 = new Bruch(2, 3);
            var result = bruch1.MultipliziereMit(bruch2);
            Assert.AreEqual(2, result.Zaehler);
            Assert.AreEqual(6, result.Nenner);
        }

        [Test]
        public void DividiereMitNull()
        {
            var bruch1 = new Bruch(1, 2);
            Assert.Throws<ArgumentException>(() => bruch1.DividiereMit(null));
        }
        [Test]
        public void DividiereMitGueltigemBurch()
        {
            var bruch1 = new Bruch(3, 4);
            var bruch2 = new Bruch(4, 3);
            var result = bruch1.DividiereMit(bruch2);
            Assert.AreEqual(9, result.Zaehler);
            Assert.AreEqual(16, result.Nenner);
            
        }
        
        
    }
}