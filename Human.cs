class Human : Character
    {
        public Human() : base(true, 100, 10, 20, "50kg", "Intelligence", "Eau", "Lignes droites")
        {
        }

        public override void DisplayCharacter()
        {
            Console.WriteLine($"ID : {IdCharacter}");
            Console.WriteLine($"Débloqué ? : {IdCharacter}");
            Console.WriteLine($"Quantité d'énergie : {QuantityEnergy}");
            Console.WriteLine($"Taille de l'inventaire : {InventorySize}");
            Console.WriteLine($"Poids de l'inventaire : {InventoryWeight}");
            Console.WriteLine($"Point fort : {StrongPoint}");
            Console.WriteLine($"Point faible : {WeakPoint}");
            Console.WriteLine($"Déplacement : {Movement}");
        }

        public override void Move(string direction)
        {
            if (direction == "up" || direction == "down" || direction == "left" || direction == "right")
            {
                Console.WriteLine($"Votre human (ID : {IdCharacter}) bouge vers le/la {direction}.");
            }
            else
            {
                Console.WriteLine($"Votre human (ID : {IdCharacter}) peut seulement bouger en ligne droite.");
            }
        }
    }