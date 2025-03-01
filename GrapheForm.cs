using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GrapheApp
{
    public partial class GrapheForm : Form
    {
        private Graphe graphe;
        private Button btnGenerer;
        private Button btnCompterBFS;
        private Button btnCompterDFS;
        private Noeud noeudSelectionne1;
        private Noeud noeudSelectionne2;
        private List<Noeud> cheminCourt;

        public GrapheForm()
        {
            InitializeComponent();
            graphe = new Graphe();
            cheminCourt = new List<Noeud>();
            noeudSelectionne1 = null;
            noeudSelectionne2 = null;
        }

        private void btnGenerer_Click(object sender, EventArgs e)
        {
            graphe = new Graphe();
            AjouterDonnees();
            this.Refresh();
        }
        private void btnCompterBFS_Click(object sender, EventArgs e)
        {
            int nombreSousGraphes = graphe.CompterSousGraphesConnexesBFS();
            MessageBox.Show($"Le nombre de sous-graphes connexes (BFS) est : {nombreSousGraphes}");

            this.Refresh();
        }


        private void btnCompterDFS_Click(object sender, EventArgs e)
        {
            int nombreSousGraphes = graphe.CompterSousGraphesConnexesDFS();

            MessageBox.Show($"Le nombre de sous-graphes connexes (DFS) est : {nombreSousGraphes}");

            this.Refresh();
        }



        private void DessinerGraphe(object sender, PaintEventArgs e)
        {
            graphe.Dessiner(e.Graphics, cheminCourt);
        }

        private void AjouterDonnees()
        {
            string[] donnees = {
                "2 1", "3 1", "4 1", "5 1", "6 1", "7 1", "8 1", "9 1", "11 1", "12 1", "13 1", "14 1",
                "18 1", "20 1", "22 1", "32 1", "3 2", "4 2", "8 2", "14 2", "18 2", "20 2", "22 2", "31 2",
                "4 3", "8 3", "9 3", "10 3", "14 3", "28 3", "29 3", "33 3", "8 4", "13 4", "14 4", "7 5",
                "11 5", "7 6", "11 6", "17 6", "17 7", "31 9", "33 9", "34 9", "34 10", "34 14", "33 15",
                "34 15", "33 16", "34 16", "33 19", "34 19", "34 20", "33 21", "34 21", "33 23", "34 23",
                "26 24", "28 24", "30 24", "33 24", "34 24", "26 25", "28 25", "32 25", "32 26", "30 27",
                "34 27", "34 28", "32 29", "34 29", "33 30", "34 30", "33 31", "34 31", "33 32", "34 32",
                "34 33"
            };

            foreach (var ligne in donnees)
            {
                string[] ids = ligne.Split(' ');
                int id1 = int.Parse(ids[0]);
                int id2 = int.Parse(ids[1]);

                graphe.AjouterNoeud(id1);
                graphe.AjouterNoeud(id2);
                graphe.AjouterLien(id1, id2);
            }
        }

        private void InitializeComponent()
        {
            
            

            // Ajout des boutons pour BFS et DFS pour compter les sous-graphes connexes
            this.btnCompterBFS = new System.Windows.Forms.Button();
            this.btnCompterDFS = new System.Windows.Forms.Button();

            // Bouton BFS pour compter les sous-graphes
            this.btnCompterBFS.Location = new System.Drawing.Point(25, 25);
            this.btnCompterBFS.Name = "btnCompterBFS";
            this.btnCompterBFS.Size = new System.Drawing.Size(120, 40);
            this.btnCompterBFS.BackColor = Color.LightGreen;
            this.btnCompterBFS.Font = new Font("Arial", 10, FontStyle.Bold);
            this.btnCompterBFS.Text = "Compter BFS";
            this.btnCompterBFS.Click += new EventHandler(this.btnCompterBFS_Click);
            //this.btnCompterBFS.Click += new EventHandler(this.btnCompterBFS_Click);

            // Bouton DFS pour compter les sous-graphes
            this.btnCompterDFS.Location = new System.Drawing.Point(25, 75);
            this.btnCompterDFS.Name = "btnCompterDFS";
            this.btnCompterDFS.Size = new System.Drawing.Size(120, 40);
            this.btnCompterDFS.BackColor = Color.LightCoral;
            this.btnCompterDFS.Font = new Font("Arial", 10, FontStyle.Bold);
            this.btnCompterDFS.Text = "Compter DFS";
            this.btnCompterDFS.Click += new EventHandler(this.btnCompterDFS_Click);
            //this.btnCompterDFS.Click += new EventHandler(this.btnCompterDFS_Click);

            // Ajout des boutons à la fenêtre
            this.Controls.Add(this.btnCompterBFS);
            this.Controls.Add(this.btnCompterDFS);


            this.btnGenerer = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.btnGenerer.Location = new System.Drawing.Point(250, 10);
            this.btnGenerer.Name = "btnGenerer";
            this.btnGenerer.Size = new System.Drawing.Size(120, 40);
            this.btnGenerer.BackColor = Color.LightSteelBlue;
            this.btnGenerer.Font = new Font("Arial", 10, FontStyle.Bold);
            this.btnGenerer.Text = "Générer Graphe";
            this.btnGenerer.Click += new EventHandler(this.btnGenerer_Click);

            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.btnGenerer);
            this.Name = "GrapheForm";
            this.Text = "Affichage du Graphe";
            this.BackColor = Color.WhiteSmoke;
            this.Paint += new PaintEventHandler(DessinerGraphe);
            this.MouseClick += new MouseEventHandler(DessinerChemin);
            this.ResumeLayout(false);
        }

        private void DessinerChemin(object sender, MouseEventArgs e)
        {
            if (noeudSelectionne1 == null)
            {
                noeudSelectionne1 = graphe.GetNoeudParPosition(e.Location);
                if (noeudSelectionne1 != null)
                {
                    this.Invalidate();
                }
            }
            else if (noeudSelectionne2 == null)
            {
                noeudSelectionne2 = graphe.GetNoeudParPosition(e.Location);
                if (noeudSelectionne2 != null)
                {
                    cheminCourt = graphe.CalculerCheminLePlusCourt(noeudSelectionne1.ID, noeudSelectionne2.ID);
                    if (cheminCourt != null && cheminCourt.Count > 0)
                    {
                        int distance = cheminCourt.Count - 1;
                        MessageBox.Show($"Chemin trouvé entre {noeudSelectionne1.ID} et {noeudSelectionne2.ID}. Nombre de liens parcourus : {distance}");
                    }
                    else
                    {
                        MessageBox.Show("Pas de chemin trouvé.");
                    }

                    noeudSelectionne1 = null;
                    noeudSelectionne2 = null;

                    this.Invalidate();
                }
            }
        }
    }

    internal class Graphe
    {
        private List<Noeud> noeuds;
        private List<Lien> liens;

        public Graphe()
        {
            noeuds = new List<Noeud>();
            liens = new List<Lien>();
        }
        public int CompterSousGraphesConnexesBFS()
        {
            int sousGraphesConnexes = 0;
            var noeudsVisites = new HashSet<Noeud>();

            foreach (var noeud in noeuds)
            {
                if (!noeudsVisites.Contains(noeud))
                {
                    // Si le noeud n'a pas été visité, lancer BFS à partir de ce noeud
                    BFS(noeud, noeudsVisites);
                    sousGraphesConnexes++;
                }
            }

            return sousGraphesConnexes;
        }

        private void BFS(Noeud noeudInitial, HashSet<Noeud> noeudsVisites)
        {
            Queue<Noeud> fileAttente = new Queue<Noeud>();
            fileAttente.Enqueue(noeudInitial);
            noeudsVisites.Add(noeudInitial);

            while (fileAttente.Count > 0)
            {
                var noeudActuel = fileAttente.Dequeue();

                // Explorer tous les voisins non visités du noeud actuel
                foreach (var lien in liens.Where(l => l.Noeud1 == noeudActuel || l.Noeud2 == noeudActuel))
                {
                    Noeud voisin = lien.Noeud1 == noeudActuel ? lien.Noeud2 : lien.Noeud1;
                    if (!noeudsVisites.Contains(voisin))
                    {
                        noeudsVisites.Add(voisin);
                        fileAttente.Enqueue(voisin);
                    }
                }
            }
        }

        public int CompterSousGraphesConnexesDFS()
        {
            int sousGraphesConnexes = 0;
            var noeudsVisites = new HashSet<Noeud>();

            foreach (var noeud in noeuds)
            {
                if (!noeudsVisites.Contains(noeud))
                {
                    // Si le noeud n'a pas été visité, lancer DFS à partir de ce noeud
                    DFS(noeud, noeudsVisites);
                    sousGraphesConnexes++;
                }
            }

            return sousGraphesConnexes;
        }

        private void DFS(Noeud noeudInitial, HashSet<Noeud> noeudsVisites)
        {
            Stack<Noeud> pile = new Stack<Noeud>();
            pile.Push(noeudInitial);
            noeudsVisites.Add(noeudInitial);

            while (pile.Count > 0)
            {
                var noeudActuel = pile.Pop();

                // Explorer tous les voisins non visités du noeud actuel
                foreach (var lien in liens.Where(l => l.Noeud1 == noeudActuel || l.Noeud2 == noeudActuel))
                {
                    Noeud voisin = lien.Noeud1 == noeudActuel ? lien.Noeud2 : lien.Noeud1;
                    if (!noeudsVisites.Contains(voisin))
                    {
                        noeudsVisites.Add(voisin);
                        pile.Push(voisin); // Empiler les voisins pour les explorer
                    }
                }
            }
        }




        public void AjouterNoeud(int id)
        {
            if (!noeuds.Exists(n => n.ID == id))
            {
                // Positionner les noeuds en cercle
                int nombreNoeuds = noeuds.Count + 1;
                double angle = 2 * Math.PI * (nombreNoeuds - 1) / 20; // 20 est le nombre de noeuds maximum, ajuster si besoin
                int rayon = 200; // rayon du cercle
                int x = (int)(300 + rayon * Math.Cos(angle));  // Le centre du cercle est à (300, 300)
                int y = (int)(300 + rayon * Math.Sin(angle));

                noeuds.Add(new Noeud(id, x, y));
            }
        }

        public void AjouterLien(int id1, int id2)
        {
            Noeud noeud1 = noeuds.Find(n => n.ID == id1);
            Noeud noeud2 = noeuds.Find(n => n.ID == id2);
            if (noeud1 != null && noeud2 != null &&
                !liens.Exists(l => (l.Noeud1 == noeud1 && l.Noeud2 == noeud2) || (l.Noeud1 == noeud2 && l.Noeud2 == noeud1)))
            {
                liens.Add(new Lien(noeud1, noeud2));
            }
        }

        public Noeud GetNoeudParPosition(Point position)
        {
            return noeuds.FirstOrDefault(n => Math.Abs(n.Position.X - position.X) < 15 && Math.Abs(n.Position.Y - position.Y) < 15);
        }

        public List<Noeud> CalculerCheminLePlusCourt(int startId, int endId)
        {
            var distances = new Dictionary<Noeud, int>();
            var parents = new Dictionary<Noeud, Noeud>();
            var noeudsNonVisites = new List<Noeud>(noeuds);

            foreach (var noeud in noeuds)
            {
                distances[noeud] = int.MaxValue;
            }

            Noeud startNode = noeuds.Find(n => n.ID == startId);
            Noeud endNode = noeuds.Find(n => n.ID == endId);

            distances[startNode] = 0;

            while (noeudsNonVisites.Count > 0)
            {
                noeudsNonVisites.Sort((n1, n2) => distances[n1] - distances[n2]);

                Noeud currentNode = noeudsNonVisites[0];
                noeudsNonVisites.Remove(currentNode);

                if (distances[currentNode] == int.MaxValue)
                    break;

                if (currentNode == endNode)
                    break;

                foreach (var lien in liens.Where(l => l.Noeud1 == currentNode || l.Noeud2 == currentNode))
                {
                    Noeud neighbor = lien.Noeud1 == currentNode ? lien.Noeud2 : lien.Noeud1;

                    int newDist = distances[currentNode] + 1;
                    if (newDist < distances[neighbor])
                    {
                        distances[neighbor] = newDist;
                        parents[neighbor] = currentNode;
                    }
                }
            }

            List<Noeud> chemin = new List<Noeud>();
            Noeud current = endNode;
            while (current != startNode)
            {
                chemin.Insert(0, current);
                current = parents.ContainsKey(current) ? parents[current] : null;
            }
            if (current == null)
                return null;

            chemin.Insert(0, startNode);

            return chemin;
        }

        public void Dessiner(Graphics g, List<Noeud> chemin)
        {
            foreach (var lien in liens)
            {
                if (chemin.Contains(lien.Noeud1) && chemin.Contains(lien.Noeud2))
                {
                    g.DrawLine(Pens.Red, lien.Noeud1.Position, lien.Noeud2.Position);
                }
                else
                {
                    g.DrawLine(Pens.Black, lien.Noeud1.Position, lien.Noeud2.Position);
                }
            }

            foreach (var noeud in noeuds)
            {
                noeud.Dessiner(g);
            }
        }
    }

    internal class Noeud
    {
        public int ID { get; }
        public Point Position { get; }

        public Noeud(int id, int x, int y)
        {
            ID = id;
            Position = new Point(x, y);
        }

        public void Dessiner(Graphics g)
        {
            g.FillEllipse(Brushes.LightSkyBlue, Position.X - 15, Position.Y - 15, 30, 30);
            g.DrawEllipse(Pens.Black, Position.X - 15, Position.Y - 15, 30, 30);

            g.DrawString(ID.ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, Position.X - 10, Position.Y - 10);
        }
    }

    internal class Lien
    {
        public Noeud Noeud1 { get; }
        public Noeud Noeud2 { get; }

        public Lien(Noeud n1, Noeud n2)
        {
            Noeud1 = n1;
            Noeud2 = n2;
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GrapheForm());
        }
    }
}
