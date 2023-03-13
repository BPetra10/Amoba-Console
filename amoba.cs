using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoba
{
	//Fejlesztettem Hibakeres�ssel
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
			// SOR FOLYTONOS BEJ�R�S
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

			// OSZLOP FOLYTONOS BEJ�R�S
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


			// FERDE BEJ�R�S
			//bal fels� sarokb�l indul, jobb als�ba
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
			//jobb fels� sarokb�l indul, bal als�ba
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
            //FERDE BEJ�R�S IF SZERKEZET:
            //bal fels� sarokb�l indul, jobb als�ba
            if (palya[0,0]!=' ' && palya[0,0]==palya[1,1] && palya[0,0] == palya[2,2])
            {
                return true;
            }
            //jobb fels� sarokb�l indul, bal als�ba
            if (palya[0, 2] != ' ' && palya[0, 2] == palya[1, 1] && palya[0, 2] == palya[2, 0])
            {
                return true;
            }
            */

			return false;
		}

		static void Main(string[] args)
		{
			Console.WriteLine("AM�BA J�T�K");
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

				Console.WriteLine("\n__ " + jatekos + " k�re __");
				Console.Write("\n Sor: ");
				//Hibakezel�s (Ne lehessen b�rmilyen bet�t, speci�lis �s egy�b karaktert megadni, csak az 1,2,3 numerikus karaktereket):
				int sor = 0;
				try
				{
					sor = int.Parse(Console.ReadKey().KeyChar.ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine("\n Nem sz�mot adt�l meg! [1-3]", e);
				}
				if (sor == 0 || sor > 3)
				{
					Console.WriteLine(" \n Adj meg egy sz�mot 1-t�l 3-ig!");
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
						Console.WriteLine("\n Nem sz�mot adt�l meg! [1-3]", e);
					}
					if (sor == 0 || sor > 3)
					{
						Console.WriteLine(" \n Adj meg egy sz�mot 1-t�l 3-ig!");
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
					Console.WriteLine("\n Nem sz�mot adt�l meg! [1-3]", e);
				}
				if (oszlop == 0 || oszlop > 3)
				{
					Console.WriteLine(" \n Adj meg egy sz�mot 1-t�l 3-ig!");
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
						Console.WriteLine("\n Nem sz�mot adt�l meg! [1-3]", e);
					}
					if (oszlop == 0 || oszlop > 3)
					{
						Console.WriteLine(" \n Adj meg egy sz�mot 1-t�l 3-ig!");
					}
				}

				//Indexel�s miatt: ha a felhaszn�lo 1. sort ad meg, indexileg az 0, ez�rt kell -- oper�tor.
				sor--;
				oszlop--;

				if (palya[sor, oszlop] == ' ')
				{
					palya[sor, oszlop] = jatekos;

					if (test(palya))
					{
						Console.WriteLine(jatekos + " gy�z�tt!");
						jatekMegy = false;
						allas(palya);
					}
					else
					{
						if (dontetlen(palya))
						{
							Console.WriteLine("D�ntetlen!");
							jatekMegy = false;
							allas(palya);
						}
					}

					xJatszik = !xJatszik;
				}
				else
				{
					Console.WriteLine("\n Nem szab�lyos l�p�s (van m�r ott valami)");
				}
			}

			Console.ReadKey();
		}
	}
}