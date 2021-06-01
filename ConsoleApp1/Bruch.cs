using System;

namespace Bruchrechner
{
    // Die folgende Klasse besitzt einige Methoden, die getestet werden sollen.
    // Überlegen Sie sich, welche mathematischen Besonderheiten gelten und testen Sie auch diese.
    // Versuchen Sie mithilfe von Tests den Quellcode in fehlerfreieren Quellcode zu transformieren.

    public class Bruch
    {
        private int zaehler;
        private int nenner;
        private Random rnd = new Random();

        public int Zaehler
        {
            get { return zaehler; }
            set { zaehler = value; }
        }

        public int Nenner
        {
            get { return nenner; }
            set
            {
                if (nenner != 0)
                    nenner = value;
            }
        }

        public Bruch(int zaehler, int nenner)
        {
            if (nenner == 0)
            {
                throw new ArgumentException();
            }

            this.zaehler = zaehler;
            this.nenner = nenner;
        }

        public void Kuerze()
        {
            int tmpn = this.nenner;
            int tmpz = this.zaehler;
            if (tmpz != 0)
            {
                int rest;
                int ggt = ggT(this.nenner, this.Zaehler);
                int divisor = Math.Abs(tmpn);

                tmpz = tmpz / ggt;
                tmpn = tmpn / ggt;
            }

            this.nenner = tmpn;
            this.zaehler = tmpz;
        }

        public static int ggT(int n, int m)
        {
            return n == m ? n : n < m ? ggT(n, m - n) : ggT(n - m, m);
        }

        public Bruch MultipliziereMit(Bruch other)
        {
            if (other == null)
            {
                throw new ArgumentException();
            }

            int tmpz = zaehler * other.zaehler;
            int tmpn = nenner * other.nenner;
            return new Bruch(tmpz, tmpn);
        }

        public Bruch DividiereMit(Bruch other)
        {
            if (other == null)
            {
                throw new ArgumentException();
            }

            int tmpz = zaehler * other.nenner;
            int tmpn = nenner * other.zaehler;
            return new Bruch(tmpz, tmpn);
        }

        public Bruch AddiereMit(Bruch other)
        {
            int tmpn = nenner * other.Nenner;
            int tmpz1 = zaehler * other.Nenner;
            int tmpz2 = other.zaehler * nenner;
            int tmpz = tmpz1 + tmpz2;
            return new Bruch(tmpz, tmpn);
        }

        public Bruch SubtrahiereMit(Bruch other)
        {
            int tmpn = nenner * other.Nenner;
            int tmpz1 = zaehler * other.Nenner;
            int tmpz2 = other.zaehler * nenner;
            int tmpz = tmpz1 - tmpz2;
            return new Bruch(tmpz, tmpn);
        }

        public void Erweitern(int number)
        {
            nenner = nenner * number;
            zaehler = zaehler * number;
        }
    }
}