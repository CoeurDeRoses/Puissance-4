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
                                                        teamColonne[j + 3][i - 1].ImageLocation != null)
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
            for (int i = 0; i < 3; i++)
            {
                // ici à chaque tour on démarre dans la colonne suivante
                for (int j = 0; j < 4; j++)
                {
                    // j,j+1 fait switcher les colonnes
                    // tandis que i, i+1 etc.. servira à switcher et tester une case sur une ligne différente

                    if (teamColonne[j][i].ImageLocation == marron &&
                        teamColonne[j + 1][i + 1].ImageLocation == marron &&
                        teamColonne[j + 2][i + 2].ImageLocation == marron &&
                        teamColonne[j + 3][i + 3].ImageLocation == null &&
                                        teamColonne[j + 3][i + 2].ImageLocation != null)
                    {
                        teamColonne[j + 3][i + 3].ImageLocation = marron;
                        tabPositionCol[j + 3] -= 1;
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

                    else if (i > 0)
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
            for (int i = 0; i < 3; i++)
            {
                // ici à chaque tour on démarre dans la colonne d'avant
                for (int j = 6; j > 2; j--)
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
                                        && teamColonne[j + 3][i - 1].ImageLocation != null)
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

            /* 
             * Au lieu de simplement se contenter de bloquer et d'attendre d'aligner 3 couleur
             * de manière indirecte puis saisir l'opportunité à gagner, 
             * puisqu'elles résultent du blocage qu'il fait uniquement
             * Vegeta devra regarder partout pour voir si il peut faire le plus grand alignement
             * 
             * Par exemple si le joueur 1 n'a que des alignement de 2 couleurs, et que c'est le tour 
             * de Vegeta et qu'il peut en aligner 3 car il a déja 2 couleur ensemble, il prend les devant
             * mais à condition que l'alignement possède non seulement la 3 ème couleur mais aussi
             * une autre case vide d'alignement possible, donc 4 au total, il ne doit pas aligner 3 couleur simplement
             * pour remplir et se retrouve bloqué le jeu mais il faut le faire avec du sens et lui faire comprendre
             * qu'il doit le faire si cela peut lui permettre de gagner.
             * 
             * Le cas dès alignement sur à 4 couleur étant traités, je vais coder les cas 
             * des alignement a 3 et 2 couleurs. Il doivent tous être placer avant les blocage
             * trier par nombre de cas
             * 
             * Code Opportunité 3 couleur avant Blocage 3 couleur mais avant Opportunité à 2 couleur
             * Code Opportunité 2 couleur avant blocage 2 couleur
             * 
             * Comme pour le Takedown à 4 couleur situé avant le blocage.
             * 
             * Si Vegeta constate que le joueur 1 possède actuellement un plus grand nombre d'alignement
             * il restera sur sa stratégie de blocage
             * 
             * Il faudra analyser tout les moyens possibles d'alignement à 3 Couleur
             * Diagonales, lignes colonnes. Si le booléen en desssous reste à false
             * 
             * Le code if(!J1peutAligner4) permettra a Vegeta de vérifier si il peut jouer
             * à condition d'avoir au moins 2 couleur et deux autres case vides
             * sur un même alignement.
             */

            bool J1peutAligner = false;
            // dès que Vegeta trouve que les J1 peut en mettre 4
            // car il possède déja 3 couleur alignés sur son tour il laisse tomber et
            /*J1peutAligner4 passe à true */

            /*** TENTATIVE ALIGNEMENT SUR 3 COULEURS   AVANT  JOUEUR 1  ***/

            /* VERIFICATION DES DIAGONALES DU JOUEURS 1*/
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
                        J1peutAligner = true; goto RetourBlocage;
                    }

                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j + 1][i + 1].ImageLocation == violet &&
                        teamColonne[j + 2][i + 2].ImageLocation == null &&
                        teamColonne[j + 3][i + 3].ImageLocation == violet &&
                                        teamColonne[j + 2][i + 1].ImageLocation != null)
                    {
                        J1peutAligner = true; goto RetourBlocage;
                    }

                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j + 1][i + 1].ImageLocation == null &&
                        teamColonne[j + 2][i + 2].ImageLocation == violet &&
                        teamColonne[j + 3][i + 3].ImageLocation == violet &&
                                        teamColonne[j + 1][i].ImageLocation != null)
                    {
                        J1peutAligner = true; goto RetourBlocage;
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
                            J1peutAligner = true; goto RetourBlocage;
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
                            J1peutAligner = true; goto RetourBlocage;
                        }

                    }

                }

            }
            //DIAGONALES MIROIR
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
                        J1peutAligner = true; goto RetourBlocage;
                    }


                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j - 1][i + 1].ImageLocation == violet &&
                        teamColonne[j - 2][i + 2].ImageLocation == null &&
                        teamColonne[j - 3][i + 3].ImageLocation == violet && teamColonne[j - 2][i + 1].ImageLocation != null)
                    {
                        J1peutAligner = true; goto RetourBlocage;
                    }


                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j - 1][i + 1].ImageLocation == null &&
                        teamColonne[j - 2][i + 2].ImageLocation == violet &&
                        teamColonne[j - 3][i + 3].ImageLocation == violet && teamColonne[j - 1][i].ImageLocation != null)
                    {
                        J1peutAligner = true; goto RetourBlocage;
                    }

                    if (i == 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j - 1][i + 1].ImageLocation == violet &&
                            teamColonne[j - 2][i + 2].ImageLocation == violet &&
                            teamColonne[j - 3][i + 3].ImageLocation == violet)
                        {
                            J1peutAligner = true; goto RetourBlocage;
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
                            J1peutAligner = true; goto RetourBlocage;
                        }

                    }
                }
            }

            /*** VERIFICATION EN LIGNES DU JOUEUR 1 ***/
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
                        J1peutAligner = true; goto RetourBlocage;
                    }

                    if (teamColonne[j][i].ImageLocation == violet &&
                       teamColonne[j + 1][i].ImageLocation == violet &&
                       teamColonne[j + 2][i].ImageLocation == violet &&
                       teamColonne[j + 3][i].ImageLocation == null && auDelaPremiereLigne
                                        && teamColonne[j + 3][i - 1].ImageLocation != null)
                    {
                        J1peutAligner = true; goto RetourBlocage;
                    }

                    if (teamColonne[j][i].ImageLocation == violet &&
                   teamColonne[j + 1][i].ImageLocation == violet &&
                   teamColonne[j + 2][i].ImageLocation == null &&
                   teamColonne[j + 3][i].ImageLocation == violet && !auDelaPremiereLigne)
                    {
                        J1peutAligner = true; goto RetourBlocage;
                    }
                    if (teamColonne[j][i].ImageLocation == violet &&
                           teamColonne[j + 1][i].ImageLocation == violet &&
                           teamColonne[j + 2][i].ImageLocation == null &&
                           teamColonne[j + 3][i].ImageLocation == violet && auDelaPremiereLigne
                                            && teamColonne[j + 2][i - 1].ImageLocation != null)
                    {
                        J1peutAligner = true; goto RetourBlocage;
                    }

                    if (teamColonne[j][i].ImageLocation == violet &&
                   teamColonne[j + 1][i].ImageLocation == null &&
                   teamColonne[j + 2][i].ImageLocation == violet &&
                   teamColonne[j + 3][i].ImageLocation == violet && !auDelaPremiereLigne)
                    {
                        J1peutAligner = true; goto RetourBlocage;
                    }

                    if (teamColonne[j][i].ImageLocation == violet &&
                           teamColonne[j + 1][i].ImageLocation == null &&
                           teamColonne[j + 2][i].ImageLocation == violet &&
                           teamColonne[j + 3][i].ImageLocation == violet && auDelaPremiereLigne
                                            && teamColonne[j + 1][i - 1].ImageLocation != null)
                    {
                        J1peutAligner = true; goto RetourBlocage;
                    }

                    if (teamColonne[j][i].ImageLocation == null &&
                   teamColonne[j + 1][i].ImageLocation == violet &&
                   teamColonne[j + 2][i].ImageLocation == violet &&
                   teamColonne[j + 3][i].ImageLocation == violet && !auDelaPremiereLigne)
                    {
                        J1peutAligner = true; goto RetourBlocage;
                    }
                    if (teamColonne[j][i].ImageLocation == null &&
                           teamColonne[j + 1][i].ImageLocation == violet &&
                           teamColonne[j + 2][i].ImageLocation == violet &&
                           teamColonne[j + 3][i].ImageLocation == violet && auDelaPremiereLigne
                                            && teamColonne[j][i - 1].ImageLocation != null)
                    {
                        J1peutAligner = true; goto RetourBlocage;
                    }



                }

                auDelaPremiereLigne = true;
            }

            auDelaPremiereLigne = false;


            /*** VERIFICATION COLONNES JOUEUR 1 ***/
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
                        J1peutAligner = true; goto RetourBlocage;
                    }
                }

            }
            RetourBlocage:;

            /* SI J1peutAligner4 reste à false Vegeta verifie ces alignements actuels et si il en trouve
             1 potentiel il met une troisième couleur il sera donc le plus proche d'aligner a 4*/

            if (!J1peutAligner)
            {
                // VERIFICATION COLONNE
                for (int i = 0; i < 7; i++)
                {
                    //Ensuite à la boucle suivante on teste toutes les combinaisons possibles sur une et mêem colonne
                    // de gagner il y'en aura 4 maximum de

                    for (int j = 0; j < 4; j++)
                    {
                        if (teamColonne[i][j].ImageLocation == marron &&
                            teamColonne[i][j + 1].ImageLocation == marron &&
                            teamColonne[i][j + 2].ImageLocation == null &&
                            teamColonne[i][j + 3].ImageLocation == null)
                        // sur une colonne la seule manière de gagner est toujorus vers le haut
                        // Donc l'index le plus gros j+3 sera le seul a devoir être nul
                        {
                            tabPositionCol[i] -= 1;
                            teamColonne[i][j + 2].Load(marron); goto PasserLeTour;
                        }
                    }

                }

                /**** VERIFICATION LIGNE */

                auDelaPremiereLigne = false;
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
                           teamColonne[j + 2][i].ImageLocation == null &&
                           teamColonne[j + 3][i].ImageLocation == null && !auDelaPremiereLigne)
                        {
                            tabPositionCol[j + 3] -= 1;
                            teamColonne[j + 3][i].Load(marron); goto PasserLeTour;
                        }
                        if (teamColonne[j][i].ImageLocation == marron &&
                           teamColonne[j + 1][i].ImageLocation == marron &&
                           teamColonne[j + 2][i].ImageLocation == null &&
                           teamColonne[j + 3][i].ImageLocation == null && auDelaPremiereLigne &&
                                                            teamColonne[j + 3][i - 1].ImageLocation != null)
                        // si c'est vide à cette case là [i] et que sur la même colonne
                        // [j+3] la case d'en bas [i-1] n'est pas vide alors Vegeta peut jouer
                        {
                            tabPositionCol[j + 3] -= 1;
                            teamColonne[j + 3][i].Load(marron); goto PasserLeTour;
                        }

                        if (teamColonne[j][i].ImageLocation == marron &&
                       teamColonne[j + 1][i].ImageLocation == null &&
                       teamColonne[j + 2][i].ImageLocation == null &&
                       teamColonne[j + 3][i].ImageLocation == marron && !auDelaPremiereLigne)
                        {
                            tabPositionCol[j + 2] -= 1;
                            teamColonne[j + 2][i].Load(marron); goto PasserLeTour;
                        }

                        if (teamColonne[j][i].ImageLocation == marron &&
                           teamColonne[j + 1][i].ImageLocation == null &&
                           teamColonne[j + 2][i].ImageLocation == null &&
                           teamColonne[j + 3][i].ImageLocation == marron && auDelaPremiereLigne &&
                                                            teamColonne[j + 2][i - 1].ImageLocation != null)
                        {
                            tabPositionCol[j + 2] -= 1;
                            teamColonne[j + 2][i].Load(marron); goto PasserLeTour;
                        }



                        if (teamColonne[j][i].ImageLocation == null &&
                       teamColonne[j + 1][i].ImageLocation == null &&
                       teamColonne[j + 2][i].ImageLocation == marron &&
                       teamColonne[j + 3][i].ImageLocation == marron && !auDelaPremiereLigne)
                        {
                            tabPositionCol[j + 1] -= 1;
                            teamColonne[j + 1][i].Load(marron); goto PasserLeTour;
                        }

                        if (teamColonne[j][i].ImageLocation == null &&
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
                       teamColonne[j + 3][i].ImageLocation == null && !auDelaPremiereLigne)
                        {
                            tabPositionCol[j] -= 1;
                            teamColonne[j][i].Load(marron); goto PasserLeTour;
                        }

                        if (teamColonne[j][i].ImageLocation == null &&
                               teamColonne[j + 1][i].ImageLocation == marron &&
                               teamColonne[j + 2][i].ImageLocation == marron &&
                               teamColonne[j + 3][i].ImageLocation == null && auDelaPremiereLigne &&
                                                                teamColonne[j][i - 1].ImageLocation != null)
                        {
                            tabPositionCol[j] -= 1;
                            teamColonne[j][i].Load(marron); goto PasserLeTour;
                        }



                    }

                    auDelaPremiereLigne = true;
                }

                auDelaPremiereLigne = false;



                /*
                 *
                 * 
                 */
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

                        if (teamColonne[j][i].ImageLocation == marron &&
                            teamColonne[j + 1][i + 1].ImageLocation == marron &&
                            teamColonne[j + 2][i + 2].ImageLocation == null &&
                            teamColonne[j + 3][i + 3].ImageLocation == null &&
                                            teamColonne[j + 3][i + 2].ImageLocation != null)
                        {
                            teamColonne[j + 3][i + 3].ImageLocation = marron;
                            tabPositionCol[j + 3] -= 1;
                            goto PasserLeTour;
                        }

                        if (teamColonne[j][i].ImageLocation == marron &&
                            teamColonne[j + 1][i + 1].ImageLocation == null &&
                            teamColonne[j + 2][i + 2].ImageLocation == null &&
                            teamColonne[j + 3][i + 3].ImageLocation == marron &&
                                            teamColonne[j + 2][i + 1].ImageLocation != null)
                        {
                            teamColonne[j + 2][i + 2].ImageLocation = marron;
                            tabPositionCol[j + 2] -= 1;
                            goto PasserLeTour;
                        }

                        if (teamColonne[j][i].ImageLocation == null &&
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
                                teamColonne[j + 3][i + 3].ImageLocation == null)
                            {
                                teamColonne[j][i].ImageLocation = marron;
                                tabPositionCol[j] -= 1;
                                goto PasserLeTour;
                            }
                        }

                        else if (i > 0)
                        {
                            if (teamColonne[j][i].ImageLocation == null &&
                                teamColonne[j + 1][i + 1].ImageLocation == marron &&
                                teamColonne[j + 2][i + 2].ImageLocation == marron &&
                                teamColonne[j + 3][i + 3].ImageLocation == null &&
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
                for (int i = 0; i < 3; i++)
                {
                    // ici à chaque tour on démarre dans la colonne d'avant
                    for (int j = 6; j > 2; j--)
                    {
                        // j,j-1 fait switcher les colonnes, donc seul sur j se fera la soustraction pour reculer
                        // vu qu'on va vers la gauche
                        // tandis que i, i+1 etc.. servira à switcher et tester une case sur une ligne différente

                        if (teamColonne[j][i].ImageLocation == marron &&
                            teamColonne[j - 1][i + 1].ImageLocation == marron &&
                            teamColonne[j - 2][i + 2].ImageLocation == null &&
                            teamColonne[j - 3][i + 3].ImageLocation == null && teamColonne[j - 3][i + 2].ImageLocation != null)
                        // attention ici on ne mets -1 mais on diminue juste la somme
                        // -1 sera nécessaire pour i seulement
                        {
                            teamColonne[j - 3][i + 3].ImageLocation = marron;
                            tabPositionCol[j - 3] -= 1;
                            goto PasserLeTour;
                        }


                        if (teamColonne[j][i].ImageLocation == marron &&
                            teamColonne[j - 1][i + 1].ImageLocation == null &&
                            teamColonne[j - 2][i + 2].ImageLocation == null &&
                            teamColonne[j - 3][i + 3].ImageLocation == marron && teamColonne[j - 2][i + 1].ImageLocation != null)
                        {
                            teamColonne[j - 2][i + 2].ImageLocation = marron;
                            tabPositionCol[j - 2] -= 1;
                            goto PasserLeTour;
                        }


                        if (teamColonne[j][i].ImageLocation == null &&
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
                                teamColonne[j - 3][i + 3].ImageLocation == null)
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
                                teamColonne[j - 3][i + 3].ImageLocation == null &&
                                                teamColonne[j][i - 1].ImageLocation != null)
                            {
                                teamColonne[j][i].ImageLocation = marron;
                                tabPositionCol[j] -= 1;
                                goto PasserLeTour;
                            }

                        }
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
                                        && teamColonne[j + 2][i - 1].ImageLocation != null)
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
                }
                auDelaPremiereLigne = true;
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
                            teamColonne[j][i - 1].ImageLocation != null)
                        {
                            teamColonne[j][i].ImageLocation = marron;
                            tabPositionCol[j] -= 1;
                            goto PasserLeTour;
                        }

                    }
                }
            }

            /*** TENTATIVE ALIGNEMENT 2 COULEURS  ***/

            /*J1peutAligner4 passe à true */

            /*** TENTATIVE ALIGNEMENT SUR 3 COULEURS   AVANT  JOUEUR 1  ***/
            J1peutAligner = false;
            /* VERIFICATION DES DIAGONALES DU JOUEURS 1*/
            for (int i = 0; i < 3; i++)
            {
                // ici à chaque tour on démarre dans la colonne suivante
                for (int j = 0; j < 4; j++)
                {
                    // j,j+1 fait switcher les colonnes
                    // tandis que i, i+1 etc.. servira à switcher et tester une case sur une ligne différente

                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j + 1][i + 1].ImageLocation == violet &&
                        teamColonne[j + 2][i + 2].ImageLocation == null &&
                        teamColonne[j + 3][i + 3].ImageLocation == null &&
                                        teamColonne[j + 3][i + 2].ImageLocation != null)
                    {
                        J1peutAligner = true; goto RetourBlocage2;
                    }

                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j + 1][i + 1].ImageLocation == null &&
                        teamColonne[j + 2][i + 2].ImageLocation == null &&
                        teamColonne[j + 3][i + 3].ImageLocation == violet &&
                                        teamColonne[j + 2][i + 1].ImageLocation != null)
                    {
                        J1peutAligner = true; goto RetourBlocage2;
                    }

                    if (teamColonne[j][i].ImageLocation == null &&
                        teamColonne[j + 1][i + 1].ImageLocation == null &&
                        teamColonne[j + 2][i + 2].ImageLocation == violet &&
                        teamColonne[j + 3][i + 3].ImageLocation == violet &&
                                        teamColonne[j + 1][i].ImageLocation != null)
                    {
                        J1peutAligner = true; goto RetourBlocage2;
                    }

                    // Pour la pemière case à la première ligne au tour 0 ils faut faire un code adapté
                    // Car on ne doit pas tester la condition teamcolonne[j][i-1] pour une ligne en dessous qui n'existe pas

                    if (i == 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j + 1][i + 1].ImageLocation == violet &&
                            teamColonne[j + 2][i + 2].ImageLocation == violet &&
                            teamColonne[j + 3][i + 3].ImageLocation == null)
                        {
                            J1peutAligner = true; goto RetourBlocage2;
                        }
                    }

                    else if (i > 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j + 1][i + 1].ImageLocation == violet &&
                            teamColonne[j + 2][i + 2].ImageLocation == violet &&
                            teamColonne[j + 3][i + 3].ImageLocation == null &&
                                            teamColonne[j][i - 1].ImageLocation != null)
                        {
                            J1peutAligner = true; goto RetourBlocage2;
                        }

                    }

                }

            }
            //DIAGONALES MIROIR
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
                        teamColonne[j - 2][i + 2].ImageLocation == null &&
                        teamColonne[j - 3][i + 3].ImageLocation == null && teamColonne[j - 3][i + 2].ImageLocation != null)
                    // attention ici on ne mets -1 mais on diminue juste la somme
                    // -1 sera nécessaire pour i seulement
                    {
                        J1peutAligner = true; goto RetourBlocage2;
                    }


                    if (teamColonne[j][i].ImageLocation == violet &&
                        teamColonne[j - 1][i + 1].ImageLocation == null &&
                        teamColonne[j - 2][i + 2].ImageLocation == null &&
                        teamColonne[j - 3][i + 3].ImageLocation == violet && teamColonne[j - 2][i + 1].ImageLocation != null)
                    {
                        J1peutAligner = true; goto RetourBlocage2;
                    }


                    if (teamColonne[j][i].ImageLocation == null &&
                        teamColonne[j - 1][i + 1].ImageLocation == null &&
                        teamColonne[j - 2][i + 2].ImageLocation == violet &&
                        teamColonne[j - 3][i + 3].ImageLocation == violet && teamColonne[j - 1][i].ImageLocation != null)
                    {
                        J1peutAligner = true; goto RetourBlocage2;
                    }

                    if (i == 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j - 1][i + 1].ImageLocation == violet &&
                            teamColonne[j - 2][i + 2].ImageLocation == violet &&
                            teamColonne[j - 3][i + 3].ImageLocation == null)
                        {
                            J1peutAligner = true; goto RetourBlocage2;
                        }
                    }

                    else if (i > 0)
                    {
                        if (teamColonne[j][i].ImageLocation == null &&
                            teamColonne[j - 1][i + 1].ImageLocation == violet &&
                            teamColonne[j - 2][i + 2].ImageLocation == violet &&
                            teamColonne[j - 3][i + 3].ImageLocation == null &&
                                            teamColonne[j][i - 1].ImageLocation != null)
                        {
                            J1peutAligner = true; goto RetourBlocage2;
                        }

                    }
                }
            }

            /*** VERIFICATION EN LIGNES DU JOUEUR 1 ***/
            for (int i = 0; i < 6; i++)
            {

                /* Ensuite 4 tour seront nécessaires car on a 4 combinaisons possibles maximum sur une ligne*/
                for (int j = 0; j < 4; j++)
                {
                    /*Comme nous testerons 4 colonnes par tour, on utilisera j+1 j+2 et j+3 pour les 3 colonnes après j*/

                    if (teamColonne[j][i].ImageLocation == violet &&
                       teamColonne[j + 1][i].ImageLocation == violet &&
                       teamColonne[j + 2][i].ImageLocation == null &&
                       teamColonne[j + 3][i].ImageLocation == null && !auDelaPremiereLigne)
                    {
                        J1peutAligner = true; goto RetourBlocage2;
                    }

                    if (teamColonne[j][i].ImageLocation == violet &&
                       teamColonne[j + 1][i].ImageLocation == violet &&
                       teamColonne[j + 2][i].ImageLocation == null &&
                       teamColonne[j + 3][i].ImageLocation == null && auDelaPremiereLigne
                                        && teamColonne[j + 3][i - 1].ImageLocation != null)
                    {
                        J1peutAligner = true; goto RetourBlocage2;
                    }

                    if (teamColonne[j][i].ImageLocation == violet &&
                   teamColonne[j + 1][i].ImageLocation == null &&
                   teamColonne[j + 2][i].ImageLocation == null &&
                   teamColonne[j + 3][i].ImageLocation == violet && !auDelaPremiereLigne)
                    {
                        J1peutAligner = true; goto RetourBlocage2;
                    }
                    if (teamColonne[j][i].ImageLocation == violet &&
                           teamColonne[j + 1][i].ImageLocation == null &&
                           teamColonne[j + 2][i].ImageLocation == null &&
                           teamColonne[j + 3][i].ImageLocation == violet && auDelaPremiereLigne
                                            && teamColonne[j + 2][i - 1].ImageLocation != null)
                    {
                        J1peutAligner = true; goto RetourBlocage2;
                    }

                    if (teamColonne[j][i].ImageLocation == null &&
                   teamColonne[j + 1][i].ImageLocation == null &&
                   teamColonne[j + 2][i].ImageLocation == violet &&
                   teamColonne[j + 3][i].ImageLocation == violet && !auDelaPremiereLigne)
                    {
                        J1peutAligner = true; goto RetourBlocage2;
                    }

                    if (teamColonne[j][i].ImageLocation == null &&
                           teamColonne[j + 1][i].ImageLocation == null &&
                           teamColonne[j + 2][i].ImageLocation == violet &&
                           teamColonne[j + 3][i].ImageLocation == violet && auDelaPremiereLigne
                                            && teamColonne[j + 1][i - 1].ImageLocation != null)
                    {
                        J1peutAligner = true; goto RetourBlocage2;
                    }

                    if (teamColonne[j][i].ImageLocation == null &&
                   teamColonne[j + 1][i].ImageLocation == violet &&
                   teamColonne[j + 2][i].ImageLocation == violet &&
                   teamColonne[j + 3][i].ImageLocation == null && !auDelaPremiereLigne)
                    {
                        J1peutAligner = true; goto RetourBlocage2;
                    }
                    if (teamColonne[j][i].ImageLocation == null &&
                           teamColonne[j + 1][i].ImageLocation == violet &&
                           teamColonne[j + 2][i].ImageLocation == violet &&
                           teamColonne[j + 3][i].ImageLocation == null && auDelaPremiereLigne
                                            && teamColonne[j][i - 1].ImageLocation != null)
                    {
                        J1peutAligner = true; goto RetourBlocage2;
                    }



                }

                auDelaPremiereLigne = true;
            }

            auDelaPremiereLigne = false;


            /*** VERIFICATION COLONNES JOUEUR 1 ***/
            for (int i = 0; i < 7; i++)
            {
                //Ensuite à la boucle suivante on teste toutes les combinaisons possibles sur une et mêem colonne
                // de gagner il y'aura  3 tour

                for (int j = 0; j < 3; j++)
                {
                    if (teamColonne[i][j].ImageLocation == violet &&
                        teamColonne[i][j + 1].ImageLocation == violet &&
                        teamColonne[i][j + 2].ImageLocation == null &&
                        teamColonne[i][j + 3].ImageLocation == null)
                    // sur une colonne la seule manière de gagner est toujours vers le haut
                    // Donc l'index le plus gros j+3 sera le seul a devoir être nul
                    {
                        J1peutAligner = true; goto RetourBlocage2;
                    }
                }

            }

            /* SI J1peutAligner4 reste à false Vegeta verifie ces alignements actuels et si il en trouve
             1 potentiel il met une troisième couleur il sera donc le plus proche d'aligner a 4*/

            if (!J1peutAligner)
            {
                // VERIFICATION COLONNE
                for (int i = 0; i < 7; i++)
                {
                    //Ensuite à la boucle suivante on teste toutes les combinaisons possibles sur une et mêem colonne
                    // de gagner il y'en aura 4 maximum de

                    for (int j = 0; j < 4; j++)
                    {
                        if (teamColonne[i][j].ImageLocation == marron &&
                            teamColonne[i][j + 1].ImageLocation == null &&
                            teamColonne[i][j + 2].ImageLocation == null &&
                            teamColonne[i][j + 3].ImageLocation == null)
                        // sur une colonne la seule manière de gagner est toujorus vers le haut
                        // Donc l'index le plus gros j+3 sera le seul a devoir être nul
                        {
                            tabPositionCol[i] -= 1;
                            teamColonne[i][j + 1].Load(marron); goto PasserLeTour;
                        }
                    }

                }

                /**** VERIFICATION LIGNE */

                auDelaPremiereLigne = false;
                // Passera a vrai si on est au de là d'un tour et sera réinitilisé à false après les boucles concernés

                // a chaque tour on passe à la ligne suivante
                for (int i = 0; i < 6; i++)
                {

                    /* Ensuite 4 tour seront nécessaires 4 on a 4 combinaisons possibles maximum sur une ligne*/
                    for (int j = 0; j < 4; j++)
                    {
                        /*Comme nous testerons 4 colonnes par tour, on utilisera j+1 j+2 et j+3 pour les 3 colonnes après j*/

                        if (teamColonne[j][i].ImageLocation == marron &&
                           teamColonne[j + 1][i].ImageLocation == null &&
                           teamColonne[j + 2][i].ImageLocation == null &&
                           teamColonne[j + 3][i].ImageLocation == null && !auDelaPremiereLigne)
                        {
                            tabPositionCol[j + 3] -= 1;
                            teamColonne[j + 3][i].Load(marron); goto PasserLeTour;
                        }
                        if (teamColonne[j][i].ImageLocation == marron &&
                           teamColonne[j + 1][i].ImageLocation == null &&
                           teamColonne[j + 2][i].ImageLocation == null &&
                           teamColonne[j + 3][i].ImageLocation == null && auDelaPremiereLigne &&
                                                            teamColonne[j + 3][i - 1].ImageLocation != null)
                        // si c'est vide à cette case là [i] et que sur la même colonne
                        // [j+3] la case d'en bas [i-1] n'est pas vide alors Vegeta peut jouer
                        {
                            tabPositionCol[j + 3] -= 1;
                            teamColonne[j + 3][i].Load(marron); goto PasserLeTour;
                        }

                        if (teamColonne[j][i].ImageLocation == null &&
                       teamColonne[j + 1][i].ImageLocation == marron &&
                       teamColonne[j + 2][i].ImageLocation == null &&
                       teamColonne[j + 3][i].ImageLocation == null && !auDelaPremiereLigne)
                        {
                            tabPositionCol[j + 2] -= 1;
                            teamColonne[j + 2][i].Load(marron); goto PasserLeTour;
                        }

                        if (teamColonne[j][i].ImageLocation == null &&
                           teamColonne[j + 1][i].ImageLocation == marron &&
                           teamColonne[j + 2][i].ImageLocation == null &&
                           teamColonne[j + 3][i].ImageLocation == null && auDelaPremiereLigne &&
                                                            teamColonne[j + 2][i - 1].ImageLocation != null)
                        {
                            tabPositionCol[j + 2] -= 1;
                            teamColonne[j + 2][i].Load(marron); goto PasserLeTour;
                        }



                        if (teamColonne[j][i].ImageLocation == null &&
                       teamColonne[j + 1][i].ImageLocation == null &&
                       teamColonne[j + 2][i].ImageLocation == marron &&
                       teamColonne[j + 3][i].ImageLocation == null && !auDelaPremiereLigne)
                        {
                            tabPositionCol[j + 1] -= 1;
                            teamColonne[j + 1][i].Load(marron); goto PasserLeTour;
                        }

                        if (teamColonne[j][i].ImageLocation == null &&
                               teamColonne[j + 1][i].ImageLocation == null &&
                               teamColonne[j + 2][i].ImageLocation == marron &&
                               teamColonne[j + 3][i].ImageLocation == null && auDelaPremiereLigne &&
                                                                teamColonne[j + 1][i - 1].ImageLocation != null)
                        {
                            tabPositionCol[j + 1] -= 1;
                            teamColonne[j + 1][i].Load(marron); goto PasserLeTour;
                        }

                        if (teamColonne[j][i].ImageLocation == null &&
                       teamColonne[j + 1][i].ImageLocation == null &&
                       teamColonne[j + 2][i].ImageLocation == null &&
                       teamColonne[j + 3][i].ImageLocation == marron && !auDelaPremiereLigne)
                        {
                            tabPositionCol[j] -= 1;
                            teamColonne[j][i].Load(marron); goto PasserLeTour;
                        }

                        if (teamColonne[j][i].ImageLocation == null &&
                               teamColonne[j + 1][i].ImageLocation == null &&
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



                /*
                 *
                 * 
                 */
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

                        if (teamColonne[j][i].ImageLocation == marron &&
                            teamColonne[j + 1][i + 1].ImageLocation == marron &&
                            teamColonne[j + 2][i + 2].ImageLocation == null &&
                            teamColonne[j + 3][i + 3].ImageLocation == null &&
                                            teamColonne[j + 3][i + 2].ImageLocation != null)
                        {
                            teamColonne[j + 3][i + 3].ImageLocation = marron;
                            tabPositionCol[j + 3] -= 1;
                            goto PasserLeTour;
                        }

                        if (teamColonne[j][i].ImageLocation == marron &&
                            teamColonne[j + 1][i + 1].ImageLocation == null &&
                            teamColonne[j + 2][i + 2].ImageLocation == null &&
                            teamColonne[j + 3][i + 3].ImageLocation == marron &&
                                            teamColonne[j + 2][i + 1].ImageLocation != null)
                        {
                            teamColonne[j + 2][i + 2].ImageLocation = marron;
                            tabPositionCol[j + 2] -= 1;
                            goto PasserLeTour;
                        }

                        if (teamColonne[j][i].ImageLocation == null &&
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
                                teamColonne[j + 3][i + 3].ImageLocation == null)
                            {
                                teamColonne[j][i].ImageLocation = marron;
                                tabPositionCol[j] -= 1;
                                goto PasserLeTour;
                            }
                        }

                        else if (i > 0)
                        {
                            if (teamColonne[j][i].ImageLocation == null &&
                                teamColonne[j + 1][i + 1].ImageLocation == marron &&
                                teamColonne[j + 2][i + 2].ImageLocation == marron &&
                                teamColonne[j + 3][i + 3].ImageLocation == null &&
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
                for (int i = 0; i < 3; i++)
                {
                    // ici à chaque tour on démarre dans la colonne d'avant
                    for (int j = 6; j > 2; j--)
                    {
                        // j,j-1 fait switcher les colonnes, donc seul sur j se fera la soustraction pour reculer
                        // vu qu'on va vers la gauche
                        // tandis que i, i+1 etc.. servira à switcher et tester une case sur une ligne différente

                        if (teamColonne[j][i].ImageLocation == marron &&
                            teamColonne[j - 1][i + 1].ImageLocation == marron &&
                            teamColonne[j - 2][i + 2].ImageLocation == null &&
                            teamColonne[j - 3][i + 3].ImageLocation == null && teamColonne[j - 3][i + 2].ImageLocation != null)
                        // attention ici on ne mets -1 mais on diminue juste la somme
                        // -1 sera nécessaire pour i seulement
                        {
                            teamColonne[j - 3][i + 3].ImageLocation = marron;
                            tabPositionCol[j - 3] -= 1;
                            goto PasserLeTour;
                        }


                        if (teamColonne[j][i].ImageLocation == marron &&
                            teamColonne[j - 1][i + 1].ImageLocation == null &&
                            teamColonne[j - 2][i + 2].ImageLocation == null &&
                            teamColonne[j - 3][i + 3].ImageLocation == marron && teamColonne[j - 2][i + 1].ImageLocation != null)
                        {
                            teamColonne[j - 2][i + 2].ImageLocation = marron;
                            tabPositionCol[j - 2] -= 1;
                            goto PasserLeTour;
                        }


                        if (teamColonne[j][i].ImageLocation == null &&
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
                                teamColonne[j - 3][i + 3].ImageLocation == null)
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
                                teamColonne[j - 3][i + 3].ImageLocation == null &&
                                                teamColonne[j][i - 1].ImageLocation != null)
                            {
                                teamColonne[j][i].ImageLocation = marron;
                                tabPositionCol[j] -= 1;
                                goto PasserLeTour;
                            }

                        }
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
                                        && teamColonne[j + 2][i - 1].ImageLocation != null)
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
                }
                auDelaPremiereLigne = true;
            }

            auDelaPremiereLigne = false;


            RetourBlocage2:;
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
                                && teamColonne[j + 1][i - 1].ImageLocation != null)
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
                }
                auDelaPremiereLigne = true;
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
                        teamColonne[j - 1][i + 1].ImageLocation == null && teamColonne[j - 1][i].ImageLocation != null)
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
    }
}
