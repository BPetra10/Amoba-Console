using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoba
{
	//Fejlesztettem Hibakereséssel
	class Program
	{
		static void allas(char[,] palya)
		{
			for (int sor = 0; sor < 3; sor++)
			{
				for (int oszlop = 0; oszlop < 3; oszlop++)
				{
					Console.Write("[" + palya[sor, oszlop] + "]");
				}
				Console.WriteLine();
			}
		}

		static bool dontetlen(char[,] palya)
		{
			int szokozok = 0;
			for (int sor = 0; sor < 3; sor++)
			{
				for (int oszlop = 0; oszlop < 3; oszlop++)
				{
					if (palya[sor, oszlop] == ' ')
					{
						szokozok++;
					}
				}
			}

			if (szokozok == 0)
			{
				return true;
			}

			return false;
		}
		static bool test(char[,] palya)
		{
			// SOR FOLYTONOS BEJÁRÁS
			for (int sor = 0; sor < 3; sor++)
			{
				int talalat = 0;
				for (int oszlop = 0; oszlop < 3; oszlop++)
				{
					if (palya[sor, 0] != ' ')
					{
						if (palya[sor, oszlop] == palya[sor, 0])
						{
							talalat++;
						}
					}
				}
				if (talalat == 3)
				{
					return true;
				}
				Console.WriteLine();
			}

			// OSZLOP FOLYTONOS BEJÁRÁS
			for (int oszlop = 0; oszlop < 3; oszlop++)
			{
				int talalat = 0;
				for (int sor = 0; sor < 3; sor++)
				{
					if (palya[0, oszlop] != ' ')
					{
						if (palya[sor, oszlop] == palya[0, oszlop])
						{
							talalat++;
						}
					}
				}
				if (talalat == 3)
				{
					return true;
				}
				Console.WriteLine();
			}


			// FERDE BEJÁRÁS
			//bal felsõ sarokból indul, jobb alsóba
			int ferde_talalat = 0;
			for (int i = 0; i < 3; i++)
			{
				if (palya[0, 0] != ' ')
				{
					if (palya[i, i] == palya[0, 0])
					{
						ferde_talalat++;
					}
				}
			}
			if (ferde_talalat == 3)
			{
				return true;
			}

			ferde_talalat = 0;
			//jobb felsõ sarokból indul, bal alsóba
			for (int i = 0; i < 3; i++)
			{
				if (palya[0, 2] != ' ')
				{
					if (palya[i, 2 - i] == palya[0, 2])
					{
						ferde_talalat++;
					}
				}
			}
			if (ferde_talalat == 3)
			{
				return true;
			}


			/*
            //FERDE BEJÁRÁS IF SZERKEZET:
            //bal felsõ sarokból indul, jobb alsóba
            if (palya[0,0]!=' ' && palya[0,0]==palya[1,1] && palya[0,0] == palya[2,2])
            {
                return true;
            }
            //jobb felsõ sarokból indul, bal alsóba
            if (palya[0, 2] != ' ' && palya[0, 2] == palya[1, 1] && palya[0, 2] == palya[2, 0])
            {
                return true;
            }
            */

			return false;
		}

		static void Main(string[] args)
		{
			Console.WriteLine("AMÕBA JÁTÉK");
			bool jatekMegy = true;
			bool xJatszik = true;
			char[,] palya = new char[3, 3];

			for (int sor = 0; sor < 3; sor++)
			{
				for (int oszlop = 0; oszlop < 3; oszlop++)
				{
					palya[sor, oszlop] = ' ';
				}
			}

			while (jatekMegy)
			{
				allas(palya);
				char jatekos;
				if (xJatszik)
				{
					jatekos = 'x';
				}
				else
				{
					jatekos = 'o';
				}

				Console.WriteLine("\n__ " + jatekos + " köre __");
				Console.Write("\n Sor: ");
				//Hibakezelés (Ne lehessen bármilyen betût, speciális és egyéb karaktert megadni, csak az 1,2,3 numerikus karaktereket):
				int sor = 0;
				try
				{
					sor = int.Parse(Console.ReadKey().KeyChar.ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine("\n Nem számot adtál meg! [1-3]", e);
				}
				if (sor == 0 || sor > 3)
				{
					Console.WriteLine(" \n Adj meg egy számot 1-tõl 3-ig!");
				}

				int[] elfogad = new int[] { 1, 2, 3 };
				while (!elfogad.Contains(sor))
				{
					Console.Write("\n Sor: ");
					try
					{
						sor = int.Parse(Console.ReadKey().KeyChar.ToString());
					}
					catch (Exception e)
					{
						Console.WriteLine("\n Nem számot adtál meg! [1-3]", e);
					}
					if (sor == 0 || sor > 3)
					{
						Console.WriteLine(" \n Adj meg egy számot 1-tõl 3-ig!");
					}
				}

				Console.Write("\n Oszlop: ");
				int oszlop = 0;

				try
				{
					oszlop = int.Parse(Console.ReadKey().KeyChar.ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine("\n Nem számot adtál meg! [1-3]", e);
				}
				if (oszlop == 0 || oszlop > 3)
				{
					Console.WriteLine(" \n Adj meg egy számot 1-tõl 3-ig!");
				}

				while (!elfogad.Contains(oszlop))
				{
					Console.Write("\n Oszlop: ");
					try
					{
						oszlop = int.Parse(Console.ReadKey().KeyChar.ToString());
					}
					catch (Exception e)
					{
						Console.WriteLine("\n Nem számot adtál meg! [1-3]", e);
					}
					if (oszlop == 0 || oszlop > 3)
					{
						Console.WriteLine(" \n Adj meg egy számot 1-tõl 3-ig!");
					}
				}

				//Indexelés miatt: ha a felhasználo 1. sort ad meg, indexileg az 0, ezért kell -- operátor.
				sor--;
				oszlop--;

				if (palya[sor, oszlop] == ' ')
				{
					palya[sor, oszlop] = jatekos;

					if (test(palya))
					{
						Console.WriteLine(jatekos + " gyõzött!");
						jatekMegy = false;
						allas(palya);
					}
					else
					{
						if (dontetlen(palya))
						{
							Console.WriteLine("Döntetlen!");
							jatekMegy = false;
							allas(palya);
						}
					}

					xJatszik = !xJatszik;
				}
				else
				{
					Console.WriteLine("\n Nem szabályos lépés (van már ott valami)");
				}
			}

			Console.ReadKey();
		}
	}
}