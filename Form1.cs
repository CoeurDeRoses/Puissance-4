using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puissance_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /*
         * Le codage du jeu puissance 4 possède plusieurs similarités avec le morpion
         * comme par exemple avoir un variable nombre de tour,au fur et mesure de
         * l'incrémentation de cette variable,  chaque nombre impair
         * correspondra au tours du joueur 1 et les nombres pairs au joueur 2
         * 
         * La différence est, qu'au lieu de switcher entre les symboles "O" et "X"
         * on switchera entre des petites images de couleurs différentes à chaque tour
         * via le code adéquat
         * 
         * Les du jeu ne seront plus des bouttons mais des images
         * 
         * on pourra choisir la colonne ou l'on veut poser son pion via le bouton
         * situé en dessous
         * 
         * Si avez vu au préalable le code sur le morpion vous remarquerez
         * qu'il y'a quelque similarités
         */

        // On initialise à 1 pour le premier tour du joueur 1
        int tour = 1;

        //le chemin d'accès de chaque image sera placé dans une variable string
        string marron = "marron.png"; // joueur 2
        string violet = "violet.png"; // Joueur 1

        /* Concernant l'affectation des pictures box, des cases donc 
         nous aurons 7 tableaux pour les 7 colonnes, composé de 6 cases, 
         * chaque bouton aura sa colonne respectif, celle juste au dessus donc
         * tableaux type PictureBox
         */

        // Maintenant on créer des variables qui vont se décrementer à chaque clique sur les boutons
        // respectifs. Car le plus grand nombre de chaque colonne se situe en bas
        // Et comme vous le savez, dans puissance 4 on commence toujours en bas
        // Elles auront pour rôle de déterminer quel case sera affecter

        static int posColonne = 5, posColonne2 = 5, posColonne3 = 5, posColonne4 = 5,
            posColonne5 = 5, posColonne6 = 5, posColonne7 = 5; // Ces variables
        // seront utilisés comme des index jusqu'a 0 en décrémentant donc elles valent 6 dans un certain sens..
        // enfin je crois XD MDR PTDR LOL

        int[] tabPositionCol = { posColonne, posColonne2, posColonne3, posColonne4,
            posColonne5, posColonne6, posColonne7};

        /* plus bas les boutons de réinitialisation de round ou total et la manière de calculer
         * 
         * les point et de trouver le vainqueur, on peut déja déclarer les variables de points
         */
        int point1 = 0; // pour le joueur 1
        int point2 = 0; // pour le joueur 2
                        //La variable pointJoueur2 sera utilisé pour Vegeta si on l'affronte

        // je garde certaines méthodes avec le même nom que dans le morpion
        private void Activation()// Les bouttons sont activés une fois le mode choisie
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
        }

        private void DesActivation()// Les bouttons sont activés une fois le mode choisie
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
        }

        //Dabord on choisi soit le mode 2 joueurs
        /*Il y'aura une variable booleen qui déterminera si le code duel entre humain sera éxecuter
         ou si le code contre l'IA sera executer, l'IA se nommera Vegeta pour le fun*/
        // la variable adversaire affiche le nom de l'opposant

        bool mode = true;// True pour le duel d'humain
        bool vainqueur = false;// Si on a un vainqueur elle deviendra TRUE
        string adversaire = "";// Necessaire pour affecter la chaine
                               // tour du joueur 2 ou tour de Vegeta

        private void DuelHumains_Click(object sender, EventArgs e)
        {
            label1.Text = "Joueur 1 nombre de point: ";
            label2.Text = "Joueur 2 nombre de point: ";
            adversaire = "Joueur 2";
            // on fait apparaitre les boutons nouveau round et recommencer
            button8.Visible = true; button9.Visible = true;
            // puis on fait disparaitre les boutons de mode
            duelHumains.Visible = false; buttonIA.Visible = false;
            Activation();
        }

        private void ButtonIA_Click(object sender, EventArgs e)
        {
            label1.Text = "Joueur 1 nombre de point: ";
            label2.Text = "Vegeta nombre de point: ";
            adversaire = "Vegeta";
            mode = false; // False pour affronter Vegeta
            button8.Visible = true; button9.Visible = true;
            duelHumains.Visible = false; buttonIA.Visible = false;
            Activation();
        }







        // Avant tout il faut gérer l'exception au cas où l'utilisateur n'as
        // pas télécharger les fichiers marron et violet ou l'un d'entre eux
        bool fichierManquant = true;

        private void button1_Click(object sender, EventArgs e)
        {
            PictureBox[] colonne =
              { pictureBox1, pictureBox2,pictureBox3,pictureBox4,pictureBox5, pictureBox6};


            do
            {

                try
                {
                    if (tour % 2 == 0 && mode)// Si c'est pair  c'est un carré Maron pour le joueur 2
                    {
                        colonne[tabPositionCol[0]].Load(marron); tabPositionCol[0] -= 1;

                        // le joueur 2 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 1
                        label3.Text = "Tour du joueur 1";


                    }

                    if (tour % 2 != 0 || !mode) // Sinon c'est un carré violet pour le joueur 1
                                                // Il faut préviser le mode IA sinon on ne rentrera que quand c'est impair
                                                // Cette condition d'obligation impair pour rentrer dans ce code  est nécessaire uniquement si
                                                //On affronte le joueur 2
                                                //Par conséquent dans le mode Vegeta il faudra indiquer 21 et tour en cas de match nul
                                                // c'est à dire le nombre de fois ou on appuie sur le bouton
                    {
                        colonne[tabPositionCol[0]].Load(violet); tabPositionCol[0] -= 1;
                        // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                        label3.Text = "Tour de " + adversaire;

                        if (!mode) // Il faut mettre la méthode vérifier
                            // sinon Même si le joueur un aligne 4 et gagne couleurs Vegeta va continuer malgré tout
                        {
                            vainqueur = Verifier();
                            if (!vainqueur)
                            {
                                Vegeta();
                            }
                        }


                    }
                    fichierManquant = false;
                }

                catch (Exception)
                {
                    MessageBox.Show
                   ("Vérifiez bien que les deux fichiers marron.png et violet.png sont dans le même dossier que puissance 4. " +
                   "Vous ne pouvez pas jouer sans eux. Fermez le jeu puis vérifiez.");
                   //+ ex.Message+ ex.StackTrace)
                    //On casse la boucle car la valeur va rester à true et bloquez le programme

                    break;

                }

            } while (fichierManquant);

            if (!vainqueur)//Il faut englober ce code sinon quand on affronte Vegeta et qu'on gagne une fois
                // le compter de point est incrémenté deux fois
                //Car on appelle la mthode Verifier en premier dans la condition if qui sert à faire jouer Vegeta
                // Vainqueur deviendra vrai si le joueur 1 ou l'IA gagne et il faut que vainqueur soit faux ici
                // cela évite donc la double atribution de point
            {
                vainqueur = Verifier();//On vérifie a chaque appuie de boutton si un alignement est trouvé
            }
            if ((tour == 42 && !vainqueur) || (tour == 21 && !mode && !vainqueur))// Après avoir effectué les 42 tours le round est terminé
            {
                label3.Text = "Personne ne gagne ce round";
            }

            //Ensuite on incrémentre pour mettre à jour le nombre de tour
            tour += 1;

            if (tabPositionCol[0] < 0)// On vérouille bouton à ce niveau de condition la colonne est pleine
            {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            PictureBox[] colonne2 =
              { pictureBox7, pictureBox8,pictureBox9,pictureBox10,pictureBox11, pictureBox12};
            do
            {

                try
                {
                    if (tour % 2 == 0 && mode)// Si c'est pair  c'est un carré Maron pour le joueur 2
                    {
                        colonne2[tabPositionCol[1]].Load(marron); tabPositionCol[1] -= 1;

                        // le joueur 2 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 1
                        label3.Text = "Tour du joueur 1";


                    }

                    if (tour % 2 != 0 || !mode) // Sinon c'est un carré violet pour le joueur 1
                    {
                        colonne2[tabPositionCol[1]].Load(violet); tabPositionCol[1] -= 1;
                        // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                        label3.Text = "Tour de " + adversaire;
                       if (!mode) // Il faut mettre la méthode vérifier
                            // sinon Même si le joueur un aligne 4 et gagne couleurs Vegeta va continuer malgré tout
                        {
                            vainqueur = Verifier();
                            if (!vainqueur)
                            {
                                Vegeta();
                            }
                        }


                    }
                    fichierManquant = false;
                }

                catch (Exception)
                {
                    MessageBox.Show
                   ("Vérifiez bien que les deux fichiers marron.png et violet.png sont dans le même dossier que puissance 4. " +
                   "Vous ne pouvez pas jouer sans eux. Fermez le jeu puis vérifiez.");
                   //+ ex.Message+ ex.StackTrace)
                    //On casse la boucle car la valeur va rester à true et bloquez le programme

                    break;

                }

            } while (fichierManquant);

            if (!vainqueur)//Il faut englober ce code sinon quand on affronte Vegeta et qu'on gagne une fois
                // le compter de point est incrémenté deux fois
                //Car on appelle la mthode Verifier en premier dans la condition if qui sert à faire jouer Vegeta
                // Vainqueur deviendra vrai si le joueur 1 ou l'IA gagne et il faut que vainqueur soit faux ici
                // cela évite donc la double atribution de point
            {
                vainqueur = Verifier();//On vérifie a chaque appuie de boutton si un alignement est trouvé
            }

            if ((tour == 42 && !vainqueur) || (tour == 21 && !mode && !vainqueur))// Après avoir effectué les 42 tours le round est terminé
            {
                label3.Text = "Personne ne gagne ce round";
            }

            //Ensuite on incrémentre pour mettre à jour le nombre de tour
            tour += 1;

            if (tabPositionCol[1] < 0)
            //Si la colonne est remplie on verouille le bouton
            {
                button2.Enabled = false;
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            PictureBox[] colonne3 =
              { pictureBox13, pictureBox14,pictureBox15,pictureBox16,pictureBox17, pictureBox18};

            do
            {

                try
                {
                    if (tour % 2 == 0 && mode)// Si c'est pair  c'est un carré Maron pour le joueur 2
                    {
                        colonne3[tabPositionCol[2]].Load(marron); tabPositionCol[2] -= 1;

                        // le joueur 2 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 1
                        label3.Text = "Tour du joueur 1";


                    }

                    if (tour % 2 != 0 || !mode) // Sinon c'est un carré violet pour le joueur 1
                    {
                        colonne3[tabPositionCol[2]].Load(violet); tabPositionCol[2] -= 1;
                        // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                        label3.Text = "Tour de " + adversaire;
                        if (!mode) // Il faut mettre la méthode vérifier
                                   // sinon Même si le joueur un aligne 4 et gagne couleurs Vegeta va continuer malgré tout
                        {
                            vainqueur = Verifier();
                            if (!vainqueur)
                            {
                                Vegeta();
                            }
                        }


                    }
                    fichierManquant = false;
                }

                catch (Exception)
                {
                    MessageBox.Show
                   ("Vérifiez bien que les deux fichiers marron.png et violet.png sont dans le même dossier que puissance 4. " +
                   "Vous ne pouvez pas jouer sans eux. Fermez le jeu puis vérifiez.");
                    //+ ex.Message+ ex.StackTrace)
                    //On casse la boucle car la valeur va rester à true et bloquez le programme

                    break;

                }

            } while (fichierManquant);

            if (!vainqueur)//Il faut englober ce code sinon quand on affronte Vegeta et qu'on gagne une fois
                           // le compter de point est incrémenté deux fois
                           //Car on appelle la mthode Verifier en premier dans la condition if qui sert à faire jouer Vegeta
                           // Vainqueur deviendra vrai si le joueur 1 ou l'IA gagne et il faut que vainqueur soit faux ici
                           // cela évite donc la double atribution de point
            {
                vainqueur = Verifier();//On vérifie a chaque appuie de boutton si un alignement est trouvé
            }

            if ((tour == 42 && !vainqueur) || (tour == 21 && !mode && !vainqueur))// Après avoir effectué les 42 tours le round est terminé
            {
                label3.Text = "Personne ne gagne ce round";
            }

            //Ensuite on incrémentre pour mettre à jour le nombre de tour
            tour += 1;
            if (tabPositionCol[2] < 0)
            //Si la colonne est remplie on verouille le bouton
            {
                button3.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PictureBox[] colonne4 =
              { pictureBox19, pictureBox20,pictureBox21,pictureBox22,pictureBox23, pictureBox24};


            do
            {

                try
                {
                    if (tour % 2 == 0 && mode)// Si c'est pair  c'est un carré Maron pour le joueur 2
                    {
                        colonne4[tabPositionCol[3]].Load(marron); tabPositionCol[3] -= 1;

                        // le joueur 2 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 1
                        label3.Text = "Tour du joueur 1";


                    }

                    if (tour % 2 != 0 || !mode) // Sinon c'est un carré violet pour le joueur 1
                    {
                        colonne4[tabPositionCol[3]].Load(violet); tabPositionCol[3] -= 1;
                        // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                        label3.Text = "Tour de " + adversaire;
                        if (!mode) // Il faut mettre la méthode vérifier
                                   // sinon Même si le joueur un aligne 4 et gagne couleurs Vegeta va continuer malgré tout
                        {
                            vainqueur = Verifier();
                            if (!vainqueur)
                            {
                                Vegeta();
                            }
                        }


                    }
                    fichierManquant = false;
                }

                catch (Exception)
                {
                    MessageBox.Show
                   ("Vérifiez bien que les deux fichiers marron.png et violet.png sont dans le même dossier que puissance 4. " +
                   "Vous ne pouvez pas jouer sans eux. Fermez le jeu puis vérifiez.");
                    //+ ex.Message+ ex.StackTrace)
                    //On casse la boucle car la valeur va rester à true et bloquez le programme

                    break;

                }

            } while (fichierManquant);

            if (!vainqueur)//Il faut englober ce code sinon quand on affronte Vegeta et qu'on gagne une fois
                           // le compter de point est incrémenté deux fois
                           //Car on appelle la mthode Verifier en premier dans la condition if qui sert à faire jouer Vegeta
                           // Vainqueur deviendra vrai si le joueur 1 ou l'IA gagne et il faut que vainqueur soit faux ici
                           // cela évite donc la double atribution de point
            {
                vainqueur = Verifier();//On vérifie a chaque appuie de boutton si un alignement est trouvé
            }

            if ((tour == 42 && !vainqueur) || (tour == 21 && !mode && !vainqueur))// Après avoir effectué les 42 tours le round est terminé
            {
                label3.Text = "Personne ne gagne ce round";
            }

            //Ensuite on incrémentre pour mettre à jour le nombre de tour
            tour += 1;
            if (tabPositionCol[3] < 0)
            //Si la colonne est remplie on verouille le bouton
            {
                button4.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PictureBox[] colonne5 =
              { pictureBox25, pictureBox26,pictureBox27,pictureBox28,pictureBox29, pictureBox30};

            do
            {

                try
                {
                    if (tour % 2 == 0 && mode)// Si c'est pair  c'est un carré Maron pour le joueur 2
                    {
                        colonne5[tabPositionCol[4]].Load(marron); tabPositionCol[4] -= 1;

                        // le joueur 2 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 1
                        label3.Text = "Tour du joueur 1";


                    }

                    if (tour % 2 != 0 || !mode) // Sinon c'est un carré violet pour le joueur 1
                    {
                        colonne5[tabPositionCol[4]].Load(violet); tabPositionCol[4] -= 1;
                        // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                        label3.Text = "Tour de " + adversaire;
                        if (!mode) // Il faut mettre la méthode vérifier
                                   // sinon Même si le joueur un aligne 4 et gagne couleurs Vegeta va continuer malgré tout
                        {
                            vainqueur = Verifier();
                            if (!vainqueur)
                            {
                                Vegeta();
                            }
                        }


                    }
                    fichierManquant = false;
                }

                catch (Exception)
                {
                    MessageBox.Show
                   ("Vérifiez bien que les deux fichiers marron.png et violet.png sont dans le même dossier que puissance 4. " +
                   "Vous ne pouvez pas jouer sans eux. Fermez le jeu puis vérifiez.");
                    //+ ex.Message+ ex.StackTrace)
                    //On casse la boucle car la valeur va rester à true et bloquez le programme

                    break;

                }

            } while (fichierManquant);

            if (!vainqueur)//Il faut englober ce code sinon quand on affronte Vegeta et qu'on gagne une fois
                           // le compter de point est incrémenté deux fois
                           //Car on appelle la mthode Verifier en premier dans la condition if qui sert à faire jouer Vegeta
                           // Vainqueur deviendra vrai si le joueur 1 ou l'IA gagne et il faut que vainqueur soit faux ici
                           // cela évite donc la double atribution de point
            {
                vainqueur = Verifier();//On vérifie a chaque appuie de boutton si un alignement est trouvé
            }

            if ((tour == 42 && !vainqueur) || (tour == 21 && !mode && !vainqueur))// Après avoir effectué les 42 tours le round est terminé
            {
                label3.Text = "Personne ne gagne ce round";
            }

            //Ensuite on incrémentre pour mettre à jour le nombre de tour
            tour += 1;
            if (tabPositionCol[4] < 0)
            //Si la colonne est remplie on verouille le bouton
            {
                button5.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PictureBox[] colonne6 =
              { pictureBox31, pictureBox32,pictureBox33,pictureBox34,pictureBox35, pictureBox36};

            do
            {

                try
                {
                    if (tour % 2 == 0 && mode)// Si c'est pair  c'est un carré Maron pour le joueur 2
                    {
                        colonne6[tabPositionCol[5]].Load(marron); tabPositionCol[5] -= 1;

                        // le joueur 2 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 1
                        label3.Text = "Tour du joueur 1";


                    }

                    if (tour % 2 != 0 || !mode) // Sinon c'est un carré violet pour le joueur 1
                    {
                        colonne6[tabPositionCol[5]].Load(violet); tabPositionCol[5] -= 1;
                        // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                        label3.Text = "Tour de " + adversaire;
                        if (!mode) // Il faut mettre la méthode vérifier
                                   // sinon Même si le joueur un aligne 4 et gagne couleurs Vegeta va continuer malgré tout
                        {
                            vainqueur = Verifier();
                            if (!vainqueur)
                            {
                                Vegeta();
                            }
                        }


                    }
                    fichierManquant = false;
                }

                catch (Exception)
                {
                    MessageBox.Show
                   ("Vérifiez bien que les deux fichiers marron.png et violet.png sont dans le même dossier que puissance 4. " +
                   "Vous ne pouvez pas jouer sans eux. Fermez le jeu puis vérifiez.");
                    //+ ex.Message+ ex.StackTrace)
                    //On casse la boucle car la valeur va rester à true et bloquez le programme

                    break;

                }

            } while (fichierManquant);

            if (!vainqueur)//Il faut englober ce code sinon quand on affronte Vegeta et qu'on gagne une fois
                           // le compter de point est incrémenté deux fois
                           //Car on appelle la mthode Verifier en premier dans la condition if qui sert à faire jouer Vegeta
                           // Vainqueur deviendra vrai si le joueur 1 ou l'IA gagne et il faut que vainqueur soit faux ici
                           // cela évite donc la double atribution de point
            {
                vainqueur = Verifier();//On vérifie a chaque appuie de boutton si un alignement est trouvé
            }

            if ((tour == 42 && !vainqueur) || (tour == 21 && !mode && !vainqueur))// Après avoir effectué les 42 tours le round est terminé
            {
                label3.Text = "Personne ne gagne ce round";
            }

            //Ensuite on incrémentre pour mettre à jour le nombre de tour
            tour += 1;
            if (tabPositionCol[5] < 0)
            //Si la colonne est remplie on verouille le bouton
            {
                button6.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PictureBox[] colonne7 =
              { pictureBox37, pictureBox38,pictureBox39,pictureBox40,pictureBox41, pictureBox42};


            do
            {

                try
                {
                    if (tour % 2 == 0 && mode)// Si c'est pair  c'est un carré Maron pour le joueur 2
                    {
                        colonne7[tabPositionCol[6]].Load(marron); tabPositionCol[6] -= 1;

                        // le joueur 2 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 1
                        label3.Text = "Tour du joueur 1";


                    }

                    if (tour % 2 != 0 || !mode) // Sinon c'est un carré violet pour le joueur 1
                    {
                        colonne7[tabPositionCol[6]].Load(violet); tabPositionCol[6] -= 1;
                        // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                        label3.Text = "Tour de " + adversaire;
                        if (!mode) // Il faut mettre la méthode vérifier
                                   // sinon Même si le joueur un aligne 4 et gagne couleurs Vegeta va continuer malgré tout
                        {
                            vainqueur = Verifier();
                            if (!vainqueur)
                            {
                                Vegeta();
                            }
                        }


                    }
                    fichierManquant = false;
                }

                catch (Exception)
                {
                    MessageBox.Show
                   ("Vérifiez bien que les deux fichiers marron.png et violet.png sont dans le même dossier que puissance 4. " +
                   "Vous ne pouvez pas jouer sans eux. Fermez le jeu puis vérifiez.");
                    //+ ex.Message+ ex.StackTrace)
                    //On casse la boucle car la valeur va rester à true et bloquez le programme

                    break;

                }

            } while (fichierManquant);

            if (!vainqueur)//Il faut englober ce code sinon quand on affronte Vegeta et qu'on gagne une fois
                           // le compter de point est incrémenté deux fois
                           //Car on appelle la mthode Verifier en premier dans la condition if qui sert à faire jouer Vegeta
                           // Vainqueur deviendra vrai si le joueur 1 ou l'IA gagne et il faut que vainqueur soit faux ici
                           // cela évite donc la double atribution de point
            {
                vainqueur = Verifier();//On vérifie a chaque appuie de boutton si un alignement est trouvé
            }

            if ((tour == 42 && !vainqueur) || (tour == 21 && !mode && !vainqueur))// Après avoir effectué les 42 tours le round est terminé
            {
                label3.Text = "Personne ne gagne ce round";
            }

            //Ensuite on incrémentre pour mettre à jour le nombre de tour
            tour += 1;
            if (tabPositionCol[6] < 0)
            //Si la colonne est remplie on verouille le bouton
            {
                button7.Enabled = false;
            }
        }

        /*
         * Fonction similaire à la fonction Verifier de morpion
         * Pour trouver les alignements, un alignement de 4 symboles donc
         * dans puissance 4
         */

    

        static PictureBox[][] teamLigne;
        static PictureBox[][] team6;
        static PictureBox[][] team5;
        static PictureBox[][] team4;

        


        private bool Verifier()
        {
            /* Dabord il faut on créer tout les associations possibles de réponses
             * 6 lignes + 7 colonnes + 6 diagonales en descendant vers le bas
             * de gauche à droite + 6 diagonales en descendant vers le bas de droite à gauche
             * 
             * il y'aura en tout 25 tableaux a créer et ils n'auront pas tous la même taille
             * Comme une on connait le nombre de tour a effectuer en avance, donc la taille en tableau
             * de chacun on utilisera le for en réunissant tout les tableaux de même tailles
             * 
             * on teste au fur et à mesure chaque grouprement
             * 
             * Par nécessicté pour la réinitialisation les groupes de tableaux auront une portée superier
             * a cette fonction
             * 
             * nous aurons donc des tableaux possèdant... des tableaux possèdannnnt ???
             * des pictures BOBOBOBOBOXXXXX comme la box le sport ! XD PTDR LOOOOOOOOOL MDR
             * Il faudra retourner un boolean pour savoir si on a un gagnant TRUE oui et FALSE non
             * cela empechera le lable 3 d'ecraser la phrase tel joueur a gagner avec aucun joueur n'a gagner
             * 
            */
            bool gagne = false;
            //Les lignes composées de chacunes 7 élements 1 2 3 4 5 6 7 !!!!!! YEAAAAAA
            PictureBox[] Ligne1 =
             {pictureBox1,pictureBox7,pictureBox13,pictureBox19,pictureBox25,pictureBox31,pictureBox37};
            PictureBox[] Ligne2 =
             {pictureBox2,pictureBox8,pictureBox14,pictureBox20,pictureBox26,pictureBox32,pictureBox38};
            PictureBox[] Ligne3 =
             {pictureBox3,pictureBox9,pictureBox15,pictureBox21,pictureBox27,pictureBox33,pictureBox39};
            PictureBox[] Ligne4 =
             {pictureBox4,pictureBox10,pictureBox16,pictureBox22,pictureBox28,pictureBox34,pictureBox40};
            PictureBox[] Ligne5 =
             {pictureBox5,pictureBox11,pictureBox17,pictureBox23,pictureBox29,pictureBox35,pictureBox41};
            PictureBox[] Ligne6 =
             {pictureBox6,pictureBox12,pictureBox18,pictureBox24,pictureBox30,pictureBox36,pictureBox42};

            PictureBox[][] teamLigneCopie = { Ligne1, Ligne2, Ligne3, Ligne4, Ligne5, Ligne6 };
            teamLigne = teamLigneCopie;

            //Je parcours chaque tableau
            foreach (PictureBox[] Ligne in teamLigne)
            {
                //Je parcours chaque élement de chaque tableau
                // En faisant apparaître 4 élements successif pour vois si ils sont 
                // égaux, donc un alignement
                // Pour déterminer le nombre de tour, on compte les 1er 4 élément pour un tour
                // et les éléments en plus seront les tour en plus 
                for (int i = 0; i < 4; i++)
                {
                    if (Ligne[i].ImageLocation == marron &&
                       Ligne[i + 1].ImageLocation == marron &&
                       Ligne[i + 2].ImageLocation == marron &&
                       Ligne[i + 3].ImageLocation == marron)
                    {
                        point2 += 1; label3.Text = adversaire + " remporte ce round";
                        lbJoueur2.Text = point2.ToString();
                        gagne = true;
                        BoutonVerrouiller();
                    }

                    if (Ligne[i].ImageLocation == violet &&
                       Ligne[i + 1].ImageLocation == violet &&
                       Ligne[i + 2].ImageLocation == violet &&
                       Ligne[i + 3].ImageLocation == violet)
                    {
                        point1 += 1; label3.Text = "Le joueur 1 remporte ce round";
                        lbJoueur1.Text = point1.ToString();
                        gagne = true;
                        BoutonVerrouiller();
                    }
                }
            }





            //Les colonnes composées de chacunes 6 élements 1 2 3 4 5 6 WOHOOOO

            /****         6 ***********/
            PictureBox[] ColonneUne =
                { pictureBox1, pictureBox2,pictureBox3,pictureBox4,pictureBox5, pictureBox6};

            PictureBox[] ColonneDeux =
                { pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12};
            PictureBox[] ColonneTrois =
                {pictureBox13, pictureBox14,pictureBox15,pictureBox16,pictureBox17, pictureBox18};
            PictureBox[] ColonneQuatre =
                {pictureBox19, pictureBox20,pictureBox21,pictureBox22,pictureBox23, pictureBox24 };
            PictureBox[] ColonneCinq =
                {pictureBox25, pictureBox26,pictureBox27,pictureBox28,pictureBox29, pictureBox30};
            PictureBox[] ColonneSix =
                {pictureBox31, pictureBox32,pictureBox33,pictureBox34,pictureBox35, pictureBox36};
            PictureBox[] ColonneSept =
                {pictureBox37, pictureBox38,pictureBox39,pictureBox40,pictureBox41, pictureBox42};


            /****         6 ***********/

            //Les diagonales n'ont pas tous la même taille je ne ferais pas de blague ici
            // Saviez vous que les gens mangent des baguettes avec des bagues au doigt ???
            // rimes blagues baguettes bagues !!!
            // HORS SUJET mais j'aime m'emporter ... beaucoup



            // Diagonales descendant vers la droite
            //4
            PictureBox[] Diagonale = { pictureBox3, pictureBox10, pictureBox17, pictureBox24 };
            //5
            PictureBox[] Diagonale2 = { pictureBox2, pictureBox9, pictureBox16, pictureBox23, pictureBox30 };
            //6
            PictureBox[] Diagonale3 =
                { pictureBox1 , pictureBox8,pictureBox15,pictureBox22,pictureBox29,pictureBox36 };
            //6
            PictureBox[] Diagonale4 =
                {pictureBox7,pictureBox14,pictureBox21,pictureBox28,pictureBox35,pictureBox42 };
            //5
            PictureBox[] Diagonale5 =
                {pictureBox13,pictureBox20,pictureBox27,pictureBox34,pictureBox41 };
            //4
            PictureBox[] Diagonale6 =
                {pictureBox19,pictureBox26,pictureBox33,pictureBox40,};


            // Diagonales descendant vers la gauche
            //4
            PictureBox[] Diagonale7 = { pictureBox39, pictureBox34, pictureBox29, pictureBox24 };
            //5
            PictureBox[] Diagonale8 =
                { pictureBox38, pictureBox33, pictureBox28, pictureBox23, pictureBox18 };
            //6
            PictureBox[] Diagonale9 =
                { pictureBox37, pictureBox32, pictureBox27, pictureBox22, pictureBox17, pictureBox12 };
            //6
            PictureBox[] Diagonale10 =
                {pictureBox31,pictureBox26, pictureBox21,pictureBox16,pictureBox11,pictureBox6};
            //5
            PictureBox[] Diagonale11 =
                {pictureBox25,pictureBox20,pictureBox15,pictureBox10,pictureBox5};
            //4
            PictureBox[] Diagonale12 = { pictureBox19, pictureBox14, pictureBox9, pictureBox4 };


            
            // Diagonales 



            //Groupement des tableau de taille 6
            PictureBox[][] team6Copie =
                {ColonneUne, ColonneDeux,ColonneTrois,
                ColonneQuatre,ColonneCinq,ColonneSix,
                ColonneSept,Diagonale3,Diagonale4, Diagonale10, Diagonale9 };
            team6 = team6Copie;

            //Je parcours chaque tableau
            foreach (PictureBox[] groupe in team6)
            {
                //Je parcours chaque élement de chaque tableau
                // En faisant apparaître 4 élements successif pour vois si ils sont 
                // égaux, donc un alignement
                // Pour déterminer le nombre de tour, on compte les 1er 4 élément pour un tour
                // et les éléments en plus seront les tour en plus 
                for (int i = 0; i < 3; i++)
                {
                    if (groupe[i].ImageLocation == marron &&
                       groupe[i + 1].ImageLocation == marron &&
                       groupe[i + 2].ImageLocation == marron &&
                       groupe[i + 3].ImageLocation == marron)
                    {

                        point2 += 1; label3.Text = adversaire + " remporte ce round";
                        lbJoueur2.Text = point2.ToString();
                        gagne = true;
                        BoutonVerrouiller();
                    }

                    if (groupe[i].ImageLocation == violet &&
                       groupe[i + 1].ImageLocation == violet &&
                       groupe[i + 2].ImageLocation == violet &&
                       groupe[i + 3].ImageLocation == violet)
                    {
                        point1 += 1; label3.Text = "Le joueur 1 remporte ce round";
                        lbJoueur1.Text = point1.ToString();
                        gagne = true;
                        BoutonVerrouiller();
                    }
                }
            }



            //Groupement des tableau de taille 5
            PictureBox[][] team5Copie = { Diagonale2, Diagonale5, Diagonale8, Diagonale11 };
            team5 = team5Copie;
            foreach (PictureBox[] groupe in team5)
            {
                //Je parcours chaque élement de chaque tableau
                // En faisant apparaître 4 élements successif pour vois si ils sont 
                // égaux, donc un alignement
                // Pour déterminer le nombre de tour, on compte les 1er 4 élément pour un tour
                // et les éléments en plus seront les tour en plus 
                for (int i = 0; i < 2; i++)
                {
                    if (groupe[i].ImageLocation == marron &&
                       groupe[i + 1].ImageLocation == marron &&
                       groupe[i + 2].ImageLocation == marron &&
                       groupe[i + 3].ImageLocation == marron)
                    {
                        point2 += 1; label3.Text = adversaire + " remporte ce round";
                        lbJoueur2.Text = point2.ToString();
                        gagne = true;
                        BoutonVerrouiller();
                    }

                    if (groupe[i].ImageLocation == violet &&
                       groupe[i + 1].ImageLocation == violet &&
                       groupe[i + 2].ImageLocation == violet &&
                       groupe[i + 3].ImageLocation == violet)
                    {
                        point1 += 1; label3.Text = "Le joueur 1 remporte ce round";
                        lbJoueur1.Text = point1.ToString();
                        gagne = true;
                        BoutonVerrouiller();
                    }
                }
            }


            //Groupement des tableau de taille 4
            PictureBox[][] team4Copie = { Diagonale, Diagonale6, Diagonale7, Diagonale12 };

            team4 = team4Copie;
            foreach (PictureBox[] groupe in team4)
            {
                // un seul tour est nécessaire pour team 4
                if (groupe[0].ImageLocation == marron &&
                   groupe[1].ImageLocation == marron &&
                   groupe[2].ImageLocation == marron &&
                   groupe[3].ImageLocation == marron)
                {
                    point2 += 1; label3.Text = adversaire + " remporte ce round";
                    lbJoueur2.Text = point2.ToString();
                    gagne = true;
                    BoutonVerrouiller();
                }

                if (groupe[0].ImageLocation == violet &&
                   groupe[1].ImageLocation == violet &&
                   groupe[2].ImageLocation == violet &&
                   groupe[3].ImageLocation == violet)
                {
                    point1 += 1; label3.Text = "Le joueur 1 remporte ce round";
                    lbJoueur1.Text = point1.ToString();
                    gagne = true;

                    BoutonVerrouiller();
                }
            }


            if (gagne)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        // Nouveau round

        //Avant le boutton

        // Cette fonction va réinitialiser les tableaux
        private void tabAzero(PictureBox[][] tab)
        {
            foreach (PictureBox[] tableau in tab)
            {
                //On met à la valeur null chaque Picture boux d'un groupement à chaque tour
                foreach (PictureBox element in tableau)
                {
                    element.ImageLocation = null;
                }
            }
        }


        private void button8_Click(object sender, EventArgs e)
        {
            // On réinitialise les variables nécessaires
            vainqueur = false;
            label3.Text = "";
            button1.Enabled = true; button2.Enabled = true;
            button3.Enabled = true; button4.Enabled = true;
            button5.Enabled = true; button6.Enabled = true;
            button7.Enabled = true;



            for (int i = 0; i < 7; i++)
            {
                tabPositionCol[i] = 5;
            }

            // Si la déclaration des groupes de tableaux aurait été faites dans la fonction verification
            // j'aurais été obligé d'écrire 42 instructions pour les 42 cellule.
            // Je... suis... un .... parresseux OUI JE LE RECONNAIS !

            // On parcourt chaque groupement de d'une team a chaque tout

            // Si on appuie sur nouveau round sans avoir jouer un seul pion
            // Une exception est levé, il faut donc faire executer ce code
            // seulement si le nombre de tour est superieur a 1

            if (tour > 1)
            {
                tabAzero(team4); tabAzero(team5); tabAzero(team6); tabAzero(teamLigne);
                // Attention à réinitialiser la variable tour
                tour = 1;
            }




        }
        // TOUT RECOMMENCER
        private void button9_Click(object sender, EventArgs e)
        {

            vainqueur = false;
            point1 = 0; point2 = 0; lbJoueur1.Text = ""; lbJoueur2.Text = "";
            label3.Text = "";
            DesActivation();

            for (int i = 0; i < 7; i++)
            {
                tabPositionCol[i] = 5;
            }
            // Si on appuie sur nouveau round sans avoir jouer un seul pion
            // Une exception est levé, il faut donc faire executer ce code
            // seulement si le nombre de tour est superieur a 1
            if (tour > 1)
            {
                tabAzero(team4); tabAzero(team5); tabAzero(team6); tabAzero(teamLigne);
                // Attention à réinitialiser la variable tour
                tour = 1;
            }

            duelHumains.Visible = true;
            buttonIA.Visible = true;

            button9.Visible = false;
            button8.Visible = false;
            mode = true;

        }

        // Si la colonne n'est pas remplie mais qu'in vainqueur est trouvé on vérrouille les boutons
        private void BoutonVerrouiller()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
        }
        PictureBox[][] teamColonne;
        private void Vegeta()
        {
            /*
             * Je vais coder la stratégie de la même manière que le morpion
             * il va d'abord se focaliser sur le blocage d'alignement potentiel du joueur 1
             * et saisir l'opportunité de gagner dès qu'il a 3 couleur identiques
             * 
             * Cas Takedown
             * Dès que Vegeta voit 3 couleur lui appartenant il place une 4 ème couleur so possible
             * 
             * Cas A Bloqueur Dès que Vegeta voit 3 couleur du joueur 1 il bloque si possible
             * 
             * Cas D bloqueur il voit 2 couleur du joueur 1 il bloque
             * 
             * Cas C il voit une couleur, il bloque un endroit 
             * 
             * 
             * La manière de coder va quand même différer
             * 
             * contrairement au morpion ou l'on peut commencer depuis n'importe où
             * ici on part du bas, toujours
             * 
             * Il faudra faire comprendre a Vegeta a quel moment il peut jouer à la ligne numéro 1,2,3 etc..
             * 
             * 
             * Par nécessité de clarté pour mieux identifier quand Vegeta peut jouer a quel ligne
             * on va créer un tableau enregistrant 7  tableaux de colonnes
             */

            // attention il faut obligatoirement mettre les picturebox dans l'ordre du
            // plus bas géographiquement au plus haut, règle à respecter.

            PictureBox[] colonne1 =
                { pictureBox6, pictureBox5, pictureBox4, pictureBox3, pictureBox2, pictureBox1 };
            PictureBox[] colonne2 =
                { pictureBox12, pictureBox11, pictureBox10, pictureBox9, pictureBox8, pictureBox7 };
            PictureBox[] colonne3 =
                { pictureBox18, pictureBox17, pictureBox16, pictureBox15, pictureBox14, pictureBox13 };
            PictureBox[] colonne4 =
                { pictureBox24, pictureBox23, pictureBox22, pictureBox21, pictureBox20, pictureBox19 };
            PictureBox[] colonne5 =
                { pictureBox30, pictureBox29, pictureBox28, pictureBox27, pictureBox26, pictureBox25 };
            PictureBox[] colonne6 =
                { pictureBox36, pictureBox35, pictureBox34, pictureBox33, pictureBox32, pictureBox31 };
            PictureBox[] colonne7 =
                { pictureBox42, pictureBox41, pictureBox40, pictureBox39, pictureBox38, pictureBox37 };

            PictureBox[][] teamColonneCopie = { colonne1, colonne2, colonne3, colonne4, colonne5, colonne6, colonne7 };
            teamColonne = teamColonneCopie;

            


            /*** TAKEDOWN D'ALIGNEMENT A 4 CASE EN COLONNE MARRON ***/
            // dans les takedown on test toujours en priorité les alignement les plus grand nous irons donc de 4 a 2
            /* 7 tour nécessaire car 7 colonnes */
            /* a chaque tour on teste une colonne différente */
            for (int i = 0; i < 7; i++)
            {
                //Ensuite à la boucle suivante on teste toutes les combinaisons possibles sur une et mêem colonne
                // de gagner il y'en aura 4 maximum de

                for (int j = 0; j < 4; j++)
                {
                    if (teamColonne[i][j].ImageLocation == marron &&
                        teamColonne[i][j + 1].ImageLocation == marron &&
                        teamColonne[i][j + 2].ImageLocation == marron &&
                        teamColonne[i][j + 3].ImageLocation == null)
                    // sur une colonne la seule manière de gagner est toujorus vers le haut
                    // Donc l'index le plus gros j+3 sera le seul a devoir être nul
                    {
                        tabPositionCol[i] -= 1;
                        teamColonne[i][j + 3].Load(marron); goto PasserLeTour;
                    }
                }

            }

            /**** TAKEDOWN EN LIGNE MARRON ***/
            /***   Je vais indiquer à Vegeta quand est ce qu'il peut jouer en hauteur 
             car si on ne lui dit pas, l'ordinateur ne pourra pas savoir par lui même quand il peut 
             jouer sur la ligne 2,3,4 par exemple. Il mettra des couleur au dessus des cases vides
             Ce qui n'est pas logiques, ***/

            /*Je vais donc coder quand c'est nécessaire une condition dans les boucles qui le permettra
             de vérifier que la case sur laquelle il veut jouer n'a pas de case vide en dessous, seul la ligne 1
             ne sera pas prise en compte car c'est la première ligne. */

            bool auDelaPremiereLigne = false;
            // Passera a vrai si on est au de là d'un tour et sera réinitilisé à false après les boucles concernés

            // a chaque tour on passe à la ligne suivante
            for (int i = 0; i < 6; i++)
            {

                /* Ensuite 4 tour seront nécessaires 4 on a 4 combinaisons possibles maximum sur une ligne*/
                for (int j = 0; j < 4; j++)
                {
                    /*Comme nous testerons 4 colonnes par tour, on utilisera j+1 j+2 et j+3 pour les 3 colonnes après j*/

                    if (teamColonne[j][i].ImageLocation == marron &&
                       teamColonne[j + 1][i].ImageLocation == marron &&
                       teamColonne[j + 2][i].ImageLocation == marron &&
                       teamColonne[j + 3][i].ImageLocation == null && !auDelaPremiereLigne)
                    {
                        tabPositionCol[j + 3] -= 1;
                        teamColonne[j + 3][i].Load(marron); goto PasserLeTour;
                    }
                        if (teamColonne[j][i].ImageLocation == marron &&
                           teamColonne[j + 1][i].ImageLocation == marron &&
                           teamColonne[j + 2][i].ImageLocation == marron &&
                           teamColonne[j + 3][i].ImageLocation == null && auDelaPremiereLigne &&
                                                            teamColonne[j + 3][i-1].ImageLocation!=null)
                            // si c'est vide à cette case là [i] et que sur la même colonne
                            // [j+3] la case d'en bas [i-1] n'est pas vide alors Vegeta peut jouer
                        {
                            tabPositionCol[j + 3] -= 1;
                            teamColonne[j + 3][i].Load(marron); goto PasserLeTour;
                        }

                    if (teamColonne[j][i].ImageLocation == marron &&
                   teamColonne[j + 1][i].ImageLocation == marron &&
                   teamColonne[j + 2][i].ImageLocation == null &&
                   teamColonne[j + 3][i].ImageLocation == marron && !auDelaPremiereLigne)
                    {
                        tabPositionCol[j + 2] -= 1;
                        teamColonne[j + 2][i].Load(marron); goto PasserLeTour;
                    }

                        if (teamColonne[j][i].ImageLocation == marron &&
                           teamColonne[j + 1][i].ImageLocation == marron &&
                           teamColonne[j + 2][i].ImageLocation == null &&
                           teamColonne[j + 3][i].ImageLocation == marron && auDelaPremiereLigne &&
                                                            teamColonne[j + 2][i - 1].ImageLocation != null)
                        {
                            tabPositionCol[j + 2] -= 1;
                            teamColonne[j + 2][i].Load(marron); goto PasserLeTour;
                        }



                    if (teamColonne[j][i].ImageLocation == marron &&
                   teamColonne[j + 1][i].ImageLocation == null &&
                   teamColonne[j + 2][i].ImageLocation == marron &&
                   teamColonne[j + 3][i].ImageLocation == marron && !auDelaPremiereLigne)
                    {
                        tabPositionCol[j + 1] -= 1;
                        teamColonne[j + 1][i].Load(marron); goto PasserLeTour;
                    }

                        if (teamColonne[j][i].ImageLocation == marron &&
                               teamColonne[j + 1][i].ImageLocation == null &&
                               teamColonne[j + 2][i].ImageLocation == marron &&
                               teamColonne[j + 3][i].ImageLocation == marron && auDelaPremiereLigne &&
                                                                teamColonne[j + 1][i - 1].ImageLocation != null)
                        {
                            tabPositionCol[j + 1] -= 1;
                            teamColonne[j + 1][i].Load(marron); goto PasserLeTour;
                        }

                    if (teamColonne[j][i].ImageLocation == null &&
                   teamColonne[j + 1][i].ImageLocation == marron &&
                   teamColonne[j + 2][i].ImageLocation == marron &&
                   teamColonne[j + 3][i].ImageLocation == marron && !auDelaPremiereLigne)
                    {
                        tabPositionCol[j] -= 1;
                        teamColonne[j][i].Load(marron); goto PasserLeTour;
                    }

                        if (teamColonne[j][i].ImageLocation == marron &&
                               teamColonne[j + 1][i].ImageLocation == marron &&
                               teamColonne[j + 2][i].ImageLocation == null &&
                               teamColonne[j + 3][i].ImageLocation == marron && auDelaPremiereLigne &&
                                                                teamColonne[j][i - 1].ImageLocation != null)
                        {
                            tabPositionCol[j] -= 1;
                            teamColonne[j][i].Load(marron); goto PasserLeTour;
                        }



                }

                auDelaPremiereLigne = true;
            }

            auDelaPremiereLigne = false;


            /*** TAKEDOWN D'ALIGNEMENT A 4 CASE MARRONS EN DIAGONALES ****/
            /*
             *
             * 
             */
            // à chaque tour on démarre à la case de la diagonale situé à la ligne au dessus
            // toujours depuis la première colonne

            // On teste toutes les diagonales allant vers la droite et le haut
            for(int i=0; i<3; i++)
            {
                // ici à chaque tour on démarre dans la colonne suivante
                for(int j=0; j<4; j++)
                {
                    // j,j+1 fait switcher les colonnes
                    // tandis que i, i+1 etc.. servira à switcher et tester une case sur une ligne différente
                  
                    if( teamColonne[j][i].ImageLocation == marron &&
                        teamColonne[j+1][i+1].ImageLocation == marron &&
                        teamColonne[j + 2][i + 2].ImageLocation == marron &&
                        teamColonne[j + 3][i + 3].ImageLocation == null && 
                                        teamColonne[j + 3][i + 2].ImageLocation != null)
                    {
                        teamColonne[j + 3][i + 3].ImageLocation = marron;
                        tabPositionCol[j + 3]-=1;
                        goto PasserLeTour;
                    }

                    if (teamColonne[j][i].ImageLocation == marron &&
                        teamColonne[j + 1][i + 1].ImageLocation == marron &&
                        teamColonne[j + 2][i + 2].ImageLocation == null &&
                        teamColonne[j + 3][i + 3].ImageLocation == marron &&
                                        teamColonne[j + 2][i + 1].ImageLocation != null)
                    {
                        teamColonne[j + 2][i + 2].ImageLocation = marron;
                        tabPositionCol[j + 2] -= 1;
                        goto PasserLeTour;
                    }

                    if (teamColonne[j][i].ImageLocation == marron &&
                        teamColonne[j + 1][i + 1].ImageLocation == null &&
                        teamColonne[j + 2][i + 2].ImageLocation == marron &&
                        teamColonne[j + 3][i + 3].ImageLocation == marron &&
                                        teamColonne[j + 1][i].ImageLocation != null)
                    {
                        teamColonne[j + 1][i + 1].ImageLocation = marron;
                        tabPositionCol[j + 1] -= 1;
                        goto PasserLeTour;
                    }

                    // Pour la pemière case à la première ligne au tour 0 ils faut faire un code adapté
                    // Car on ne doit pas tester la condition teamcolonne[j][i-1] pour une ligne en dessous qui n'existe pas

                    if (i == 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j + 1][i + 1].ImageLocation == marron &&
                            teamColonne[j + 2][i + 2].ImageLocation == marron &&
                            teamColonne[j + 3][i + 3].ImageLocation == marron)
                        {
                            teamColonne[j][i].ImageLocation = marron;
                            tabPositionCol[j] -= 1;
                            goto PasserLeTour;
                        }
                    }

                    else  if (i > 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j + 1][i + 1].ImageLocation == marron &&
                            teamColonne[j + 2][i + 2].ImageLocation == marron &&
                            teamColonne[j + 3][i + 3].ImageLocation == marron &&
                                            teamColonne[j][i - 1].ImageLocation != null)
                        {
                            teamColonne[j][i].ImageLocation = marron;
                            tabPositionCol[j] -= 1;
                            goto PasserLeTour;
                        }

                    }

                }
               
            }

           

            // à chaque tour on démarre à la case de la diagonale situé à la ligne au dessus
            // toujours depuis la dernière colonne
            //Mirroir on test toutes les diagonales allant vers la gauche et en haut
            for (int i = 0; i <3; i++)
            {
                // ici à chaque tour on démarre dans la colonne d'avant
                for (int j = 6; j >2; j--)
                {
                    // j,j-1 fait switcher les colonnes, donc seul sur j se fera la soustraction pour reculer
                    // vu qu'on va vers la gauche
                    // tandis que i, i+1 etc.. servira à switcher et tester une case sur une ligne différente

                    if (teamColonne[j][i].ImageLocation == marron &&
                        teamColonne[j - 1][i + 1].ImageLocation == marron &&
                        teamColonne[j - 2][i + 2].ImageLocation == marron &&
                        teamColonne[j - 3][i + 3].ImageLocation == null && teamColonne[j - 3][i + 2].ImageLocation != null)
                    // attention ici on ne mets -1 mais on diminue juste la somme
                    // -1 sera nécessaire pour i seulement
                    {
                        teamColonne[j - 3][i + 3].ImageLocation = marron;
                        tabPositionCol[j - 3] -= 1;
                        goto PasserLeTour;
                    }
                    

                    if (teamColonne[j][i].ImageLocation == marron &&
                        teamColonne[j - 1][i + 1].ImageLocation == marron &&
                        teamColonne[j - 2][i + 2].ImageLocation == null &&
                        teamColonne[j - 3][i + 3].ImageLocation == marron && teamColonne[j - 2][i + 1].ImageLocation != null)
                    {
                        teamColonne[j - 2][i + 2].ImageLocation = marron;
                        tabPositionCol[j - 2] -= 1;
                        goto PasserLeTour;
                    }
                    

                    if (teamColonne[j][i].ImageLocation == marron &&
                        teamColonne[j - 1][i + 1].ImageLocation == null &&
                        teamColonne[j - 2][i + 2].ImageLocation == marron &&
                        teamColonne[j - 3][i + 3].ImageLocation == marron && teamColonne[j - 1][i].ImageLocation != null)
                    {
                        teamColonne[j - 1][i + 1].ImageLocation = marron;
                        tabPositionCol[j - 1] -= 1;
                        goto PasserLeTour;
                    }

                    if (i == 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j - 1][i + 1].ImageLocation == marron &&
                            teamColonne[j - 2][i + 2].ImageLocation == marron &&
                            teamColonne[j - 3][i + 3].ImageLocation == marron)
                        {
                            teamColonne[j][i].ImageLocation = marron;
                            tabPositionCol[j] -= 1;
                            goto PasserLeTour;
                        }
                    }

                    else if (i > 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j - 1][i + 1].ImageLocation == marron &&
                            teamColonne[j - 2][i + 2].ImageLocation == marron &&
                            teamColonne[j - 3][i + 3].ImageLocation == marron &&
                                            teamColonne[j][i - 1].ImageLocation != null)
                        {
                            teamColonne[j][i].ImageLocation = marron;
                            tabPositionCol[j] -= 1;
                            goto PasserLeTour;
                        }

                    }
                }
            }

         









            /*** BLOCAGE D'ALIGNEMENT A 4 CASE VIOLETTE EN LIGNE  ***/
            // dans les blocages on test toujours en priorité les alignement les plus grand
            // Nous irons de 4 a 3 puis a 2

            /* 6 tours nécessaires dans la boucle, car 6 lignes en testant les 7 colonnes en même temps */

            /*a chaque tour les mêmes index de chaque colonne sont testé toutes les case à la même ligne */
            // donc a chaque tour on test une ligne différente
            for (int i = 0; i < 6; i++)
            {

                /* Ensuite 4 tour seront nécessaires car on a 4 combinaisons possibles maximum sur une ligne*/
                for (int j = 0; j < 4; j++)
                {
                    /*Comme nous testerons 4 colonnes par tour, on utilisera j+1 j+2 et j+3 pour les 3 colonnes après j*/

                    if (teamColonne[j][i].ImageLocation == violet &&
                       teamColonne[j + 1][i].ImageLocation == violet &&
                       teamColonne[j + 2][i].ImageLocation == violet &&
                       teamColonne[j + 3][i].ImageLocation == null && !auDelaPremiereLigne)
                    {
                        tabPositionCol[j + 3] -= 1;
                        teamColonne[j + 3][i].Load(marron); goto PasserLeTour;
                    }

                        if (teamColonne[j][i].ImageLocation == violet &&
                           teamColonne[j + 1][i].ImageLocation == violet &&
                           teamColonne[j + 2][i].ImageLocation == violet &&
                           teamColonne[j + 3][i].ImageLocation == null && auDelaPremiereLigne
                                            && teamColonne[j + 3][i-1].ImageLocation != null)
                        {
                            tabPositionCol[j + 3] -= 1;
                            teamColonne[j + 3][i].Load(marron); goto PasserLeTour;
                        }

                    if (teamColonne[j][i].ImageLocation == violet &&
                   teamColonne[j + 1][i].ImageLocation == violet &&
                   teamColonne[j + 2][i].ImageLocation == null &&
                   teamColonne[j + 3][i].ImageLocation == violet && !auDelaPremiereLigne)
                    {
                        tabPositionCol[j + 2] -= 1;
                        teamColonne[j + 2][i].Load(marron); goto PasserLeTour;
                    }
                        if (teamColonne[j][i].ImageLocation == violet &&
                               teamColonne[j + 1][i].ImageLocation == violet &&
                               teamColonne[j + 2][i].ImageLocation == null &&
                               teamColonne[j + 3][i].ImageLocation == violet && auDelaPremiereLigne
                                                && teamColonne[j + 2][i - 1].ImageLocation != null)
                        {
                            tabPositionCol[j + 2] -= 1;
                            teamColonne[j + 2][i].Load(marron); goto PasserLeTour;
                        }

                    if (teamColonne[j][i].ImageLocation == violet &&
                   teamColonne[j + 1][i].ImageLocation == null &&
                   teamColonne[j + 2][i].ImageLocation == violet &&
                   teamColonne[j + 3][i].ImageLocation == violet && !auDelaPremiereLigne)
                    {
                        tabPositionCol[j + 1] -= 1;
                        teamColonne[j + 1][i].Load(marron); goto PasserLeTour;
                    }

                        if (teamColonne[j][i].ImageLocation == violet &&
                               teamColonne[j + 1][i].ImageLocation == null &&
                               teamColonne[j + 2][i].ImageLocation == violet &&
                               teamColonne[j + 3][i].ImageLocation == violet && auDelaPremiereLigne
                                                && teamColonne[j + 1][i - 1].ImageLocation != null)
                        {
                            tabPositionCol[j + 1] -= 1;
                            teamColonne[j + 1][i].Load(marron); goto PasserLeTour;
                        }

                    if (teamColonne[j][i].ImageLocation == null &&
                   teamColonne[j + 1][i].ImageLocation == violet &&
                   teamColonne[j + 2][i].ImageLocation == violet &&
                   teamColonne[j + 3][i].ImageLocation == violet && !auDelaPremiereLigne)
                    {
                        tabPositionCol[j] -= 1;
                        teamColonne[j][i].Load(marron); goto PasserLeTour;
                    }
                    if (teamColonne[j][i].ImageLocation == null &&
                           teamColonne[j + 1][i].ImageLocation == violet &&
                           teamColonne[j + 2][i].ImageLocation == violet &&
                           teamColonne[j + 3][i].ImageLocation == violet && auDelaPremiereLigne
                                            && teamColonne[j][i - 1].ImageLocation != null)
                    {
                        tabPositionCol[j] -= 1;
                        teamColonne[j][i].Load(marron); goto PasserLeTour;
                    }



                }

                auDelaPremiereLigne = true;
            }

            auDelaPremiereLigne = false;


            // BLOCAGE ALIGNEMENT DIAGONALES EN VIOLET 4 COULEURS *******/

            // à chaque tour on démarre à la case de la diagonale situé à la ligne au dessus
            // toujours depuis la première colonne

            // On teste toutes les diagonales allant vers la droite et le haut
            for (int i = 0; i < 3; i++)
            {
                // ici à chaque tour on démarre dans la colonne suivante
                for (int j = 0; j < 4; j++)
                {
                    // j,j+1 fait switcher les colonnes
                    // tandis que i, i+1 etc.. servira à switcher et tester une case sur une ligne différente

                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j + 1][i + 1].ImageLocation == violet &&
                        teamColonne[j + 2][i + 2].ImageLocation == violet &&
                        teamColonne[j + 3][i + 3].ImageLocation == null &&
                                        teamColonne[j + 3][i + 2].ImageLocation != null)
                    {
                        teamColonne[j + 3][i + 3].ImageLocation = marron;
                        tabPositionCol[j + 3] -= 1;
                        goto PasserLeTour;
                    }

                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j + 1][i + 1].ImageLocation == violet &&
                        teamColonne[j + 2][i + 2].ImageLocation == null &&
                        teamColonne[j + 3][i + 3].ImageLocation == violet &&
                                        teamColonne[j + 2][i + 1].ImageLocation != null)
                    {
                        teamColonne[j + 2][i + 2].ImageLocation = marron;
                        tabPositionCol[j + 2] -= 1;
                        goto PasserLeTour;
                    }

                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j + 1][i + 1].ImageLocation == null &&
                        teamColonne[j + 2][i + 2].ImageLocation == violet &&
                        teamColonne[j + 3][i + 3].ImageLocation == violet &&
                                        teamColonne[j + 1][i].ImageLocation != null)
                    {
                        teamColonne[j + 1][i + 1].ImageLocation = marron;
                        tabPositionCol[j + 1] -= 1;
                        goto PasserLeTour;
                    }

                    // Pour la pemière case à la première ligne au tour 0 ils faut faire un code adapté
                    // Car on ne doit pas tester la condition teamcolonne[j][i-1] pour une ligne en dessous qui n'existe pas

                    if (i == 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j + 1][i + 1].ImageLocation == violet &&
                            teamColonne[j + 2][i + 2].ImageLocation == violet &&
                            teamColonne[j + 3][i + 3].ImageLocation == violet)
                        {
                            teamColonne[j][i].ImageLocation = marron;
                            tabPositionCol[j] -= 1;
                            goto PasserLeTour;
                        }
                    }

                    else if (i > 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j + 1][i + 1].ImageLocation == violet &&
                            teamColonne[j + 2][i + 2].ImageLocation == violet &&
                            teamColonne[j + 3][i + 3].ImageLocation == violet &&
                                            teamColonne[j][i - 1].ImageLocation != null)
                        {
                            teamColonne[j][i].ImageLocation = marron;
                            tabPositionCol[j] -= 1;
                            goto PasserLeTour;
                        }

                    }

                }

            }
            // BLOCAGE MIRROIR ALIGNEMENT EN VIOLET 4 COULEURS
            //Mirroir on test toutes les diagonales allant vers la gauche et en haut
            for (int i = 0; i < 3; i++)
            {
                // ici à chaque tour on démarre dans la colonne d'avant
                for (int j = 6; j > 2; j--)
                {
                    // j,j-1 fait switcher les colonnes, donc seul sur j se fera la soustraction pour reculer
                    // vu qu'on va vers la gauche
                    // tandis que i, i+1 etc.. servira à switcher et tester une case sur une ligne différente

                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j - 1][i + 1].ImageLocation == violet &&
                        teamColonne[j - 2][i + 2].ImageLocation == violet &&
                        teamColonne[j - 3][i + 3].ImageLocation == null && teamColonne[j - 3][i + 2].ImageLocation != null)
                    // attention ici on ne mets -1 mais on diminue juste la somme
                    // -1 sera nécessaire pour i seulement
                    {
                        teamColonne[j - 3][i + 3].ImageLocation = marron;
                        tabPositionCol[j - 3] -= 1;
                        goto PasserLeTour;
                    }


                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j - 1][i + 1].ImageLocation == violet &&
                        teamColonne[j - 2][i + 2].ImageLocation == null &&
                        teamColonne[j - 3][i + 3].ImageLocation == violet && teamColonne[j - 2][i + 1].ImageLocation != null)
                    {
                        teamColonne[j - 2][i + 2].ImageLocation = marron;
                        tabPositionCol[j - 2] -= 1;
                        goto PasserLeTour;
                    }


                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j - 1][i + 1].ImageLocation == null &&
                        teamColonne[j - 2][i + 2].ImageLocation == violet &&
                        teamColonne[j - 3][i + 3].ImageLocation == violet && teamColonne[j - 1][i].ImageLocation != null)
                    {
                        teamColonne[j - 1][i + 1].ImageLocation = marron;
                        tabPositionCol[j - 1] -= 1;
                        goto PasserLeTour;
                    }

                    if (i == 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j - 1][i + 1].ImageLocation == violet &&
                            teamColonne[j - 2][i + 2].ImageLocation == violet &&
                            teamColonne[j - 3][i + 3].ImageLocation == violet)
                        {
                            teamColonne[j][i].ImageLocation = marron;
                            tabPositionCol[j] -= 1;
                            goto PasserLeTour;
                        }
                    }

                    else if (i > 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j - 1][i + 1].ImageLocation == violet &&
                            teamColonne[j - 2][i + 2].ImageLocation == violet &&
                            teamColonne[j - 3][i + 3].ImageLocation == violet &&
                                            teamColonne[j][i - 1].ImageLocation != null)
                        {
                            teamColonne[j][i].ImageLocation = marron;
                            tabPositionCol[j] -= 1;
                            goto PasserLeTour;
                        }

                    }
                }
            }

            /*** BLOCAGE ALIGNEMENT 4 CASE VIOLLETTES EN COLONNES ***/

            for (int i = 0; i < 7; i++)
            {
                //Ensuite à la boucle suivante on teste toutes les combinaisons possibles sur une et mêem colonne
                // de gagner il y'aura  3 tour

                for (int j = 0; j < 3; j++)
                {
                    if (teamColonne[i][j].ImageLocation == violet &&
                        teamColonne[i][j + 1].ImageLocation == violet &&
                        teamColonne[i][j + 2].ImageLocation == violet &&
                        teamColonne[i][j + 3].ImageLocation == null)
                    // sur une colonne la seule manière de gagner est toujours vers le haut
                    // Donc l'index le plus gros j+3 sera le seul a devoir être nul
                    {
                        tabPositionCol[i] -= 1;
                        teamColonne[i][j + 3].Load(marron); goto PasserLeTour;
                    }
                }

            }

            /*** BLOCAGE ALIGNEMENT 3 CASES VIOLETTES EN LIGNES ***/
            for (int i = 0; i < 6; i++)
            {

                /* Ensuite 5 tour nécessaires*/
                for (int j = 0; j < 5; j++)
                {


                    if (teamColonne[j][i].ImageLocation == violet &&
                       teamColonne[j + 1][i].ImageLocation == violet &&
                       teamColonne[j + 2][i].ImageLocation == null && !auDelaPremiereLigne)
                    {
                        tabPositionCol[j + 2] -= 1;
                        teamColonne[j + 2][i].Load(marron); goto PasserLeTour;
                    }

                        if (teamColonne[j][i].ImageLocation == violet &&
                           teamColonne[j + 1][i].ImageLocation == violet &&
                           teamColonne[j + 2][i].ImageLocation == null && auDelaPremiereLigne
                                            && teamColonne[j + 2][i-1].ImageLocation != null)
                        {
                            tabPositionCol[j + 2] -= 1;
                            teamColonne[j + 2][i].Load(marron); goto PasserLeTour;
                        }

                    if (teamColonne[j][i].ImageLocation == violet &&
                   teamColonne[j + 1][i].ImageLocation == null &&
                   teamColonne[j + 2][i].ImageLocation == violet && !auDelaPremiereLigne)
                    {
                        tabPositionCol[j + 1] -= 1;
                        teamColonne[j + 1][i].Load(marron); goto PasserLeTour;
                    }

                        if (teamColonne[j][i].ImageLocation == violet &&
                               teamColonne[j + 1][i].ImageLocation == null &&
                               teamColonne[j + 2][i].ImageLocation == violet && auDelaPremiereLigne
                                                && teamColonne[j + 1][i - 1].ImageLocation != null)
                        {
                            tabPositionCol[j + 1] -= 1;
                            teamColonne[j + 1][i].Load(marron); goto PasserLeTour;
                        }

                    if (teamColonne[j][i].ImageLocation == null &&
                   teamColonne[j + 1][i].ImageLocation == violet &&
                   teamColonne[j + 2][i].ImageLocation == violet && !auDelaPremiereLigne)
                    {
                        tabPositionCol[j] -= 1;
                        teamColonne[j][i].Load(marron); goto PasserLeTour;
                    }

                        if (teamColonne[j][i].ImageLocation == null &&
                               teamColonne[j + 1][i].ImageLocation == violet &&
                               teamColonne[j + 2][i].ImageLocation == violet && auDelaPremiereLigne
                                                && teamColonne[j][i - 1].ImageLocation != null)
                        {
                            tabPositionCol[j] -= 1;
                            teamColonne[j][i].Load(marron); goto PasserLeTour;
                        }
                } auDelaPremiereLigne = true;
            }

            auDelaPremiereLigne = false;

            /*** BLOCAGE ALIGNEMENT 3 CASE VIOLLETTES EN COLONNES ***/
            for (int i = 0; i < 7; i++)
            {
                //Ensuite à la boucle suivante on teste toutes les combinaisons possibles sur une et mêem colonne
                // de gagner il y'aura  4 tour

                for (int j = 0; j < 4; j++)
                {
                    if (teamColonne[i][j].ImageLocation == violet &&
                        teamColonne[i][j + 1].ImageLocation == violet &&
                        teamColonne[i][j + 2].ImageLocation == null)
                    // sur une colonne la seule manière de gagner est toujours vers le haut
                    // Donc l'index le plus gros j+3 sera le seul a devoir être nul
                    {
                        tabPositionCol[i] -= 1;
                        teamColonne[i][j + 2].Load(marron); goto PasserLeTour;
                    }
                }

            }

            // BLOCAGE ALIGNEMENT DIAGONALES EN VIOLET 3 COULEURS *******/

            // à chaque tour on démarre à la case de la diagonale situé à la ligne au dessus
            // toujours depuis la première colonne

            // On teste toutes les diagonales allant vers la droite et le haut
            for (int i = 0; i < 4; i++)
            {
                // ici à chaque tour on démarre dans la colonne suivante
                for (int j = 0; j < 5; j++)
                {
                    // j,j+1 fait switcher les colonnes
                    // tandis que i, i+1 etc.. servira à switcher et tester une case sur une ligne différente

                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j + 1][i + 1].ImageLocation == violet &&
                        teamColonne[j + 2][i + 2].ImageLocation == null &&
                                        teamColonne[j + 2][i + 1].ImageLocation != null)
                    {
                        teamColonne[j + 2][i + 2].ImageLocation = marron;
                        tabPositionCol[j + 2] -= 1;
                        goto PasserLeTour;
                    }

                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j + 1][i + 1].ImageLocation == null &&
                        teamColonne[j + 2][i + 2].ImageLocation == violet &&
                                        teamColonne[j + 1][i].ImageLocation != null)
                    {
                        teamColonne[j + 1][i + 1].ImageLocation = marron;
                        tabPositionCol[j + 1] -= 1;
                        goto PasserLeTour;
                    }

                    // Pour la pemière case à la première ligne au tour 0 ils faut faire un code adapté
                    // Car on ne doit pas tester la condition teamcolonne[j][i-1] pour une ligne en dessous qui n'existe pas

                    if (i == 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j + 1][i + 1].ImageLocation == violet &&
                            teamColonne[j + 2][i + 2].ImageLocation == violet)
                        {
                            teamColonne[j][i].ImageLocation = marron;
                            tabPositionCol[j] -= 1;
                            goto PasserLeTour;
                        }
                    }

                    else if (i > 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j + 1][i + 1].ImageLocation == violet &&
                            teamColonne[j + 2][i + 2].ImageLocation == violet &&
                                            teamColonne[j][i - 1].ImageLocation != null)
                        {
                            teamColonne[j][i].ImageLocation = marron;
                            tabPositionCol[j] -= 1;
                            goto PasserLeTour;
                        }

                    }

                }

            }
            // BLOCAGE MIRROIR ALIGNEMENT EN VIOLET 3 COULEURS
            //Mirroir on test toutes les diagonales allant vers la gauche et en haut
            for (int i = 0; i < 3; i++)
            {
                // ici à chaque tour on démarre dans la colonne d'avant
                for (int j = 6; j > 2; j--)
                {
                    // j,j-1 fait switcher les colonnes, donc seul sur j se fera la soustraction pour reculer
                    // vu qu'on va vers la gauche
                    // tandis que i, i+1 etc.. servira à switcher et tester une case sur une ligne différente

                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j - 1][i + 1].ImageLocation == violet &&
                        teamColonne[j - 2][i + 2].ImageLocation == null && teamColonne[j - 2][i + 1].ImageLocation != null)
                    // attention ici on ne mets -1 mais on diminue juste la somme
                    // -1 sera nécessaire pour i seulement
                    {
                        teamColonne[j - 2][i + 2].ImageLocation = marron;
                        tabPositionCol[j - 2] -= 1;
                        goto PasserLeTour;
                    }


                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j - 1][i + 1].ImageLocation == null &&
                        teamColonne[j - 2][i + 2].ImageLocation == violet && teamColonne[j - 1][i].ImageLocation != null)
                    {
                        teamColonne[j - 1][i + 1].ImageLocation = marron;
                        tabPositionCol[j - 1] -= 1;
                        goto PasserLeTour;
                    }

                    if (i == 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j - 1][i + 1].ImageLocation == violet &&
                            teamColonne[j - 2][i + 2].ImageLocation == violet)
                        {
                            teamColonne[j][i].ImageLocation = marron;
                            tabPositionCol[j] -= 1;
                            goto PasserLeTour;
                        }
                    }

                    else if (i > 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j - 1][i + 1].ImageLocation == violet &&
                            teamColonne[j - 2][i + 2].ImageLocation == violet &&
                            teamColonne[j][i-1].ImageLocation != null)
                        {
                            teamColonne[j][i].ImageLocation = marron;
                            tabPositionCol[j] -= 1;
                            goto PasserLeTour;
                        }

                    }
                }
            }

            /*** BLOCAGE ALIGNEMENT 2 CASES VIOLETTES EN LIGNES ***/
            for (int i = 0; i < 6; i++)
            {


                /* Ensuite 6 tour nécessaires*/
                for (int j = 0; j < 6; j++)
                {
                   


                    if (teamColonne[j][i].ImageLocation == violet &&
                       teamColonne[j + 1][i].ImageLocation == null && !auDelaPremiereLigne)
                    {
                        tabPositionCol[j + 1] -= 1;
                        teamColonne[j + 1][i].Load(marron); goto PasserLeTour;
                    }

                        if (teamColonne[j][i].ImageLocation == violet &&
                           teamColonne[j + 1][i].ImageLocation == null && auDelaPremiereLigne
                                    && teamColonne[j + 1][i-1].ImageLocation != null)
                        {
                            tabPositionCol[j + 1] -= 1;
                            teamColonne[j + 1][i].Load(marron); goto PasserLeTour;
                        }

                    if (teamColonne[j][i].ImageLocation == null &&
                   teamColonne[j + 1][i].ImageLocation == violet && !auDelaPremiereLigne)
                    {
                        tabPositionCol[j] -= 1;
                        teamColonne[j][i].Load(marron); goto PasserLeTour;
                    }

                        if (teamColonne[j][i].ImageLocation == null &&
                               teamColonne[j + 1][i].ImageLocation == violet && auDelaPremiereLigne
                                        && teamColonne[j][i - 1].ImageLocation != null)
                        {
                            tabPositionCol[j] -= 1;
                            teamColonne[j][i].Load(marron); goto PasserLeTour;
                        }
                } auDelaPremiereLigne = true;
            }

            auDelaPremiereLigne = false;
            /*** BLOCAGE ALIGNEMENT 2 CASE VIOLLETTES EN COLONNES ***/
            for (int i = 0; i < 7; i++)
            {
                //Ensuite à la boucle suivante on teste toutes les combinaisons possibles sur une et mêem colonne
                // de gagner il y'aura  4 tour

                for (int j = 0; j < 5; j++)
                {
                    if (teamColonne[i][j].ImageLocation == violet &&
                        teamColonne[i][j + 1].ImageLocation == null)
                    // sur une colonne la seule manière de gagner est toujours vers le haut
                    // Donc l'index le plus gros j+3 sera le seul a devoir être nul
                    {
                        tabPositionCol[i] -= 1;
                        teamColonne[i][j + 1].Load(marron); goto PasserLeTour;
                    }
                }

            }

            // BLOCAGE ALIGNEMENT DIAGONALES EN VIOLET 2 COULEURS *******/

            // à chaque tour on démarre à la case de la diagonale situé à la ligne au dessus
            // toujours depuis la première colonne

            // On teste toutes les diagonales allant vers la droite et le haut
            for (int i = 0; i < 5; i++)
            {
                // ici à chaque tour on démarre dans la colonne suivante
                for (int j = 0; j < 6; j++)
                {
                    // j,j+1 fait switcher les colonnes
                    // tandis que i, i+1 etc.. servira à switcher et tester une case sur une ligne différente

                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j + 1][i + 1].ImageLocation == null && 
                        teamColonne[j + 1][i].ImageLocation != null)
                    {
                        teamColonne[j + 1][i + 1].ImageLocation = marron;
                        tabPositionCol[j + 1] -= 1;
                        goto PasserLeTour;
                    }

                    // Pour la pemière case à la première ligne au tour 0 ils faut faire un code adapté
                    // Car on ne doit pas tester la condition teamcolonne[j][i-1] pour une ligne en dessous qui n'existe pas

                    if (i == 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j + 1][i + 1].ImageLocation == violet)
                        {
                            teamColonne[j][i].ImageLocation = marron;
                            tabPositionCol[j] -= 1;
                            goto PasserLeTour;
                        }
                    }

                    else if (i > 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j + 1][i + 1].ImageLocation == violet &&
                                            teamColonne[j][i - 1].ImageLocation != null)
                        {
                            teamColonne[j][i].ImageLocation = marron;
                            tabPositionCol[j] -= 1;
                            goto PasserLeTour;
                        }

                    }

                }

            }
            // BLOCAGE MIRROIR ALIGNEMENT EN VIOLET 2 COULEURS
            //Mirroir on test toutes les diagonales allant vers la gauche et en haut
            for (int i = 0; i < 3; i++)
            {
                // ici à chaque tour on démarre dans la colonne d'avant
                for (int j = 6; j > 2; j--)
                {
                    // j,j-1 fait switcher les colonnes, donc seul sur j se fera la soustraction pour reculer
                    // vu qu'on va vers la gauche
                    // tandis que i, i+1 etc.. servira à switcher et tester une case sur une ligne différente

                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j - 1][i + 1].ImageLocation == null && teamColonne[j-1][i].ImageLocation != null)
                    // attention ici on ne mets -1 mais on diminue juste la somme
                    // -1 sera nécessaire pour i seulement
                    {
                        teamColonne[j - 1][i + 1].ImageLocation = marron;
                        tabPositionCol[j - 1] -= 1;
                        goto PasserLeTour;
                    }

                    

                    if (i == 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j - 1][i + 1].ImageLocation == violet)
                        {
                            teamColonne[j][i].ImageLocation = marron;
                            tabPositionCol[j] -= 1;
                            goto PasserLeTour;
                        }
                    }

                    else if (i > 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j - 1][i + 1].ImageLocation == violet &&
                            teamColonne[j][i - 1].ImageLocation != null)
                        {
                            teamColonne[j][i].ImageLocation = marron;
                            tabPositionCol[j] -= 1;
                            goto PasserLeTour;
                        }

                    }
                }
            }

            PasserLeTour:;




        }

        /*
         * SI le joueur 1 mets des couleurs un peu partout sans chercher à les aligner rapidement
         * Cette fonction va permettre à Vegeta de vérifier si il peut aligner un lus grand nombre
         * de couleurs avant le J1.
         * 
         * Supposons par exemple que le J1 mets une couleur en bas derniyre case à droite Vegeta le bloque juste à côté
         * Puis le J1 mets une couleur en bas à dernière cas gauche. Au lieu de le bloquer encore Vegeta place une couleur
         * à côté celle qui l'a précédemment mise.
         * 
         * Cette fonction va permettre à Vegeta de prendre l'offensive et d'être le premier à aligner 
         * un plus grand nombre de couleur et potentielement Enchainer pour gagner.
         * 
         * Il faudra une boucle permettant à Vegeta de Vérifier si effectivement le J1 n'a pas l'air 
         * d'aligner pour gagner rapidement et de jouer ne conséquence Enchainer envoie true. Dans le cas contraire, il y'a
         * une menace de la part du J1 de gagner et Vegeta continue son jeu de bloqueur, Enchainer envoie false.
         * 
         * Cette fonction n'est pas totalement terminé pour le moment
         * Elle n'agira que sur la ligne 1 et si le J1 à aligner deux couleur ou non
         */

        private bool Enchainer()
        {
            // Pour l'instant je vérifie si le joueur 1 possède 2 violet ensembles
            /*Pendant le tour de Vegeta mais avant que Vegeta ne joue 
             * Si le joueur 1 n'a pas ce cas et que Vegeta a déja jouer
             Alors il vérifie si une case est vide pour aligner du marron à la case qu'i la remplie
             précédemment */


            bool vegetaAJouer = false;
            //Variable sui servira à faire comprendre dans les boucles de test dans la méthode Vegeta
            // qu'il a jouer et qu'il devra passer son tour


            //bool auDelaPremièreLigne = false;
            int nbCouleurJ1=0, nbCouleurVegeta=0;
            
            // Pour chaque ligne
            for(int i=5; i>=0; i--)
            {
                //Pour chaque case de cette ligne
                for(int j=0; j<7; j++)
                {
                    /*
                     * Chaque fois qu'il il y'a du violet on incrémente
                     */
                    if(teamLigne[i][j].ImageLocation == violet)
                    {
                        nbCouleurJ1 += 1;
                    }

                    /*
                     * Si c'est du marron on remets à zero
                     */
                    else
                    {
                        nbCouleurJ1 = 0;
                    }
                    
                }

                // Si aucun alignement menaçant du J1 est trouvé alors Vegeta commence à en construire un
                if(nbCouleurJ1<2)
                {

                    for(int j = 0; j<6; j++)
                    {
                        if (teamLigne[i][j].ImageLocation == marron
                            && teamLigne[i][j+1].ImageLocation == null)
                        {
                            teamLigne[i][j + 1].ImageLocation = marron;
                            vegetaAJouer = true;
                            goto Terminer;
                            
                        }
                        if (teamLigne[i][j].ImageLocation == null
                            && teamLigne[i][j + 1].ImageLocation == marron)
                        {
                            teamLigne[i][j].ImageLocation = marron;
                            vegetaAJouer = true;  goto Terminer;
                        }
                    }
                }

                break; // Uniquement la ligne un pour le moment
            }

            Terminer:;

            return vegetaAJouer;

        }
    }
}
    
    
    

