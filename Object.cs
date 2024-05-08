class Object : Character
    {
        public Object() : base(true, 0, 0, 0, "N/A", "N/A", "N/A", "Zigzag")
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
                Console.WriteLine($"Votre object (ID : {IdCharacter}) bouge vers le/la {direction} en zig zag.");
            }
            else
            {
                Console.WriteLine($"Votre object (ID : {IdCharacter}) peut seulement bouger en zig zag.");
            }
        }
    }