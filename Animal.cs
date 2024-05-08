// class Animal : Character
// {
//     public Animal() : base(true, 80, 15, 80, 30, "Montagne", "Eau", "Saute de 2 cases")
//     {
//     }

//     public override void DisplayCharacter()
//     {
//         Console.WriteLine($"ID : {IdCharacter}");
//         Console.WriteLine($"Débloqué ? : {IdCharacter}");
//         Console.WriteLine($"Quantité d'énergie : {QuantityEnergy}");
//         Console.WriteLine($"Taille de l'inventaire : {InventorySize}");
//         Console.WriteLine($"Poids de l'inventaire : {InventoryWeight}");
//         Console.WriteLine($"Point fort : {StrongPoint}");
//         Console.WriteLine($"Point faible : {WeakPoint}");
//         Console.WriteLine($"Déplacement : {Movement}");
//     }

//     public override void Move(string direction, int roll, World world)
//     {

//         int oldX = world.GetCharacterX();
//         int oldY = world.GetCharacterY();

//         int oldPoint = world.IsInCircle(oldX, oldY) ? 1 : 0;

//         int newX = -1;
//         int newY = -1;

//         switch (direction.ToLower())
//         {
//             case "gauche":
//                 newX = world.GetCharacterX() ;
//                 newY = world.GetCharacterY() - roll * 2;
//                 break;
//             case "droite":
//                 newX = world.GetCharacterX() ;
//                 newY = world.GetCharacterY() + roll * 2;
//                 break;
//             case "haut":
//                 newX = world.GetCharacterX()  - roll * 2;
//                 newY = world.GetCharacterY();
//                 break;
//             case "bas":
//                 newX = world.GetCharacterX() + roll * 2;
//                 newY = world.GetCharacterY() ;
//                 break;
//             default:
//                 Console.WriteLine("Direction invalide");
//                 return;
//         }

//         if (world.Mat[newX, newY] == IdWeakness1 || world.Mat[newX, newY] == IdWeakness2)
//         {
//             Console.WriteLine($"Votre animal (ID : {IdCharacter}) ne pas aller dans {WeakPoint}.");

//         } else if (newX >= 0 && newX < world.Mat.GetLength(0) && newY >= 0 && newY < world.Mat.GetLength(1) && world.Mat[newX, newY] != IdWeakness1 && world.Mat[newX, newY] != IdWeakness2)
//         {
//             world.Mat[newX, newY] = 17;
//             world.Mat[oldX, oldY] = oldPoint; 
//             QuantityEnergy -= ManageEnergy;
//             Console.WriteLine($"Votre animal (ID : {IdCharacter}) bouge vers le/la {direction}.");
//         } else
//         {
//             Console.WriteLine("Impossible de se déplacer dans cette direction");
//         }
//     }
// }