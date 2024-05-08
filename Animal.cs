// class Animal : Character
//     {
//         public Animal() : base(true, 80, 5, 15, "30kg", "Agility", "Cannot speak", "Jumping")
//         {
//         }

//         public override void DisplayCharacter()
//         {
//             Console.WriteLine($"ID : {IdCharacter}");
//             Console.WriteLine($"Débloqué ? : {IdCharacter}");
//             Console.WriteLine($"Quantité d'énergie : {QuantityEnergy}");
//             Console.WriteLine($"Taille de l'inventaire : {InventorySize}");
//             Console.WriteLine($"Poids de l'inventaire : {InventoryWeight}");
//             Console.WriteLine($"Point fort : {StrongPoint}");
//             Console.WriteLine($"Point faible : {WeakPoint}");
//             Console.WriteLine($"Déplacement : {Movement}");
//         }

//         public override void Move(string direction, int roll, World world)
//         {
//             if (direction == "up" || direction == "down" || direction == "left" || direction == "right")
//             {
//                 Console.WriteLine($"Votre animal (ID : {IdCharacter}) sautent de 3 vers la/le {direction}.");
//                 QuantityEnergy-= 15;

//             }
//             else
//             {
//                 Console.WriteLine($"Votre animal (ID : {IdCharacter}) peut seulement sauter en ligne droite.");
//             }
//         }
//     }