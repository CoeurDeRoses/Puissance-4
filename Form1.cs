﻿using System;
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

        int posColonne = 5, posColonne2 = 5, posColonne3 = 5, posColonne4 = 5,
            posColonne5 = 5, posColonne6 = 5, posColonne7 = 5;

        /* plus bas les boutons de réinitialisation de round ou total et la manière de calculer
         * 
         * les point et de trouver le vainqueur, on peut déja déclarer les variables de points
         */
        int point1 = 0; // pour le joueur 1
        int point2 = 0; // pour le joueur 2
        bool vainqueur = false;// Si on a un vainqueur elle deviendra TRUE
        private void button1_Click(object sender, EventArgs e)
        {
            PictureBox[] colonne =
              { pictureBox1, pictureBox2,pictureBox3,pictureBox4,pictureBox5, pictureBox6};



            if (tour % 2 == 0)// Si c'est pair  c'est un carré Maron pour le joueur 2
            {
                colonne[posColonne].Load(marron); posColonne -= 1;

                // le joueur 2 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 1
                label3.Text = "Tour du joueur 1";


            }

            if (tour % 2 != 0) // Sinon c'est un carré violet pour le joueur 1
            {
                colonne[posColonne].Load(violet); posColonne -= 1;
                // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                label3.Text = "Tour du joueur 2";

            }
            vainqueur = Verifier();//On vérifie a chaque appuie de boutton si un alignement est trouvé

            if (tour == 42 && !vainqueur)// Après avoir effectué les 42 tours le round est terminé
            {
                label3.Text = "Personne ne gagne ce round";
            }

            //Ensuite on incrémentre pour mettre à jour le nombre de tour
            tour += 1;

            if (posColonne < 0)// On vérouille bouton à ce niveau de condition la colonne est pleine
            {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            PictureBox[] colonne2 =
              { pictureBox7, pictureBox8,pictureBox9,pictureBox10,pictureBox11, pictureBox12};


            if (tour % 2 == 0)// Si c'est pair  c'est un carré Maron pour le joueur 2
            {
                colonne2[posColonne2].Load(marron); posColonne2 -= 1;

                // le joueur 2 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 1
                label3.Text = "Tour du joueur 1";


            }

            if (tour % 2 != 0) // Sinon c'est un carré violet pour le joueur 1
            {
                colonne2[posColonne2].Load(violet); posColonne2 -= 1;
                // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                label3.Text = "Tour du joueur 2";

            }
            vainqueur = Verifier();//On vérifie a chaque appuie de boutton si un alignement est trouvé

            if (tour == 42 && !vainqueur)// Après avoir effectué les 42 tours le round est terminé
            {
                label3.Text = "Personne ne gagne ce round";
            }

            //Ensuite on incrémentre pour mettre à jour le nombre de tour
            tour += 1;

            if (posColonne2 < 0)
            //Si la colonne est remplie on verouille le bouton
            {
                button2.Enabled = false;
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            PictureBox[] colonne3 =
              { pictureBox13, pictureBox14,pictureBox15,pictureBox16,pictureBox17, pictureBox18};




            if (tour % 2 == 0)// Si c'est pair  c'est un carré Maron pour le joueur 2
            {
                colonne3[posColonne3].Load(marron); posColonne3 -= 1;

                // le joueur 2 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 1
                label3.Text = "Tour du joueur 1";


            }

            if (tour % 2 != 0) // Sinon c'est un carré violet pour le joueur 1
            {
                colonne3[posColonne3].Load(violet); posColonne3 -= 1;
                // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                label3.Text = "Tour du joueur 2";

            }
            vainqueur = Verifier();//On vérifie a chaque appuie de boutton si un alignement est trouvé

            if (tour == 42 && !vainqueur)// Après avoir effectué les 42 tours le round est terminé
            {
                label3.Text = "Personne ne gagne ce round";
            }

            //Ensuite on incrémentre pour mettre à jour le nombre de tour
            tour += 1;
            if (posColonne3 < 0)
            //Si la colonne est remplie on verouille le bouton
            {
                button3.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PictureBox[] colonne4 =
              { pictureBox19, pictureBox20,pictureBox21,pictureBox22,pictureBox23, pictureBox24};




            if (tour % 2 == 0)// Si c'est pair  c'est un carré Maron pour le joueur 2
            {
                colonne4[posColonne4].Load(marron); posColonne4 -= 1;

                // le joueur 2 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 1
                label3.Text = "Tour du joueur 1";
                // Vérouillage du bouton

            }

            if (tour % 2 != 0)  // Sinon c'est un carré violet pour le joueur 1
            {
                colonne4[posColonne4].Load(violet); posColonne4 -= 1;
                // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                label3.Text = "Tour du joueur 2";

            }
            vainqueur = Verifier();//On vérifie a chaque appuie de boutton si un alignement est trouvé

            if (tour == 42 && !vainqueur)// Après avoir effectué les 42 tours le round est terminé
            {
                label3.Text = "Personne ne gagne ce round";
            }

            //Ensuite on incrémentre pour mettre à jour le nombre de tour
            tour += 1;
            if (posColonne4 < 0)
            //Si la colonne est remplie on verouille le bouton
            {
                button4.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PictureBox[] colonne5 =
              { pictureBox25, pictureBox26,pictureBox27,pictureBox28,pictureBox29, pictureBox30};




            if (tour % 2 == 0)// Si c'est pair  c'est un carré Maron pour le joueur 2
            {
                colonne5[posColonne5].Load(marron); posColonne5 -= 1;

                // le joueur 2 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 1
                label3.Text = "Tour du joueur 1";
                // Vérouillage du bouton

            }

            if (tour % 2 != 0)  // Sinon c'est un carré violet pour le joueur 1
            {
                colonne5[posColonne5].Load(violet); posColonne5 -= 1;
                // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                label3.Text = "Tour du joueur 2";

            }

            vainqueur = Verifier();//On vérifie a chaque appuie de boutton si un alignement est trouvé

            if (tour == 42 && !vainqueur)// Après avoir effectué les 42 tours le round est terminé
            {
                label3.Text = "Personne ne gagne ce round";
            }

            //Ensuite on incrémentre pour mettre à jour le nombre de tour
            tour += 1;
            if (posColonne5 < 0)
            //Si la colonne est remplie on verouille le bouton
            {
                button5.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PictureBox[] colonne6 =
              { pictureBox31, pictureBox32,pictureBox33,pictureBox34,pictureBox35, pictureBox36};




            if (tour % 2 == 0)// Si c'est pair  c'est un carré Maron pour le joueur 2
            {
                colonne6[posColonne6].Load(marron); posColonne6 -= 1;

                // le joueur 2 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 1
                label3.Text = "Tour du joueur 1";
                // Vérouillage du bouton

            }

            if (tour % 2 != 0)  // Sinon c'est un carré violet pour le joueur 1
            {
                colonne6[posColonne6].Load(violet); posColonne6 -= 1;
                // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                label3.Text = "Tour du joueur 2";

            }

            vainqueur = Verifier();//On vérifie a chaque appuie de boutton si un alignement est trouvé

            if (tour == 42 && !vainqueur)// Après avoir effectué les 42 tours le round est terminé
            {
                label3.Text = "Personne ne gagne ce round";
            }

            //Ensuite on incrémentre pour mettre à jour le nombre de tour
            tour += 1;
            if (posColonne6 < 0)
            //Si la colonne est remplie on verouille le bouton
            {
                button6.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PictureBox[] colonne7 =
              { pictureBox37, pictureBox38,pictureBox39,pictureBox40,pictureBox41, pictureBox42};



            if (tour % 2 == 0)// Si c'est pair  c'est un carré Maron pour le joueur 2
            {
                colonne7[posColonne7].Load(marron); posColonne7 -= 1;

                // le joueur 2 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 1
                label3.Text = "Tour du joueur 1";
                // Vérouillage du bouton

            }

            if (tour % 2 != 0)  // Sinon c'est un carré violet pour le joueur 1
            {
                colonne7[posColonne7].Load(violet); posColonne7 -= 1;
                // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                label3.Text = "Tour du joueur 2";

            }

            vainqueur = Verifier();//On vérifie a chaque appuie de boutton si un alignement est trouvé

            if (tour == 42 && !vainqueur)// Après avoir effectué les 42 tours le round est terminé
            {
                label3.Text = "Personne ne gagne ce round";
            }

            //Ensuite on incrémentre pour mettre à jour le nombre de tour
            tour += 1;
            if (posColonne7 < 0)
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
                        point2 += 1; label3.Text = "Le joueur 2 remporte ce round";
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

            //Groupement des tableau de taille 6
            PictureBox[][] team6Copie =
                {ColonneUne, ColonneDeux,ColonneTrois,
                ColonneQuatre,ColonneCinq,ColonneSix,
                ColonneSept,Diagonale3,Diagonale4 };
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

                        point2 += 1; label3.Text = "Le joueur 2 remporte ce round";
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
                        point2 += 1; label3.Text = "Le joueur 2 remporte ce round";
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
                    point2 += 1; label3.Text = "Le joueur 2 remporte ce round";
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
            
            label3.Text = "";
            button1.Enabled = true; button2.Enabled = true;
            button3.Enabled = true; button4.Enabled = true;
            button5.Enabled = true; button6.Enabled = true;
            button7.Enabled = true;



            posColonne = 5; posColonne2 = 5; posColonne3 = 5; posColonne4 = 5;
            posColonne5 = 5; posColonne6 = 5; posColonne7 = 5;

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
             point1 = 0; point2 = 0; lbJoueur1.Text = ""; lbJoueur2.Text = "";
            label3.Text = "";
            button1.Enabled = true; button2.Enabled = true;
            button3.Enabled = true; button4.Enabled = true;
            button5.Enabled = true; button6.Enabled = true;
            button7.Enabled = true;

            posColonne = 5; posColonne2 = 5; posColonne3 = 5; posColonne4 = 5;
            posColonne5 = 5; posColonne6 = 5; posColonne7 = 5;
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
    }
}
    
    
    

