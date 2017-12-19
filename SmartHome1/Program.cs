using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using ClassLibrary1;

namespace SmartHome1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Room> rooms = new List<Room>();
           
            int menu;
            while (true)
            {
                bool exit = false;

                while (true)
                {
                    Console.Clear();
                    Console.Write("1-Добавить помещение\n2-Удалить помещение\n3-Добавить устройство\n4-Удалить устройство\n5-Список помещений\n");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("0-ВЫХОД\n");
                    Console.ResetColor();

                    bool result = int.TryParse(Console.ReadLine(), out menu);

                    if (menu == 0)
                    {
                        exit = true;
                        break;
                    }

                    if (menu == 1 || menu == 2 || menu == 3 || menu == 4 || menu == 5)
                        break;
                    else
                        Console.WriteLine("Некорректный ввод\n");
                }

                if (exit)
                {
                    break;
                }

                switch (menu)
                {
                    case 1:
                        #region если выбрали Добавить помещение

                        Console.Clear();
                        Console.WriteLine("Добавление помещения...");
                        Room room = new Room();
                        
                        Console.Write("Введите название помещения (список доступных помещений - ");

                        if (rooms.Count > 0)
                        {
                            foreach (var item in rooms)
                            {
                                Console.Write(item.Name + ", ");
                            }
                            Console.Write("\b\b  \b\b");
                        }
                        else
                        {
                            Console.Write("0");
                        }
                        Console.Write("): ");
                        
                        room.Name = Console.ReadLine();

                        rooms.Add(room);
                        Console.WriteLine();
                        break;
                        #endregion
                    case 2:
                        #region если выбрали Удалить помещение
                        Console.Clear();
                        if (rooms.Count > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Удаление помещения...");

                            Console.Write("Введите название помещения (список доступных помещений - ");
                            foreach (var item in rooms)
                            {
                                Console.Write(item.Name + ", ");
                            }
                            Console.Write("\b\b): ");

                            string nameOfRoom = Console.ReadLine();

                            bool found = false;
                            for (int i = 0; i < rooms.Count; i++)
                            {
                                if (rooms[i].Name == nameOfRoom)
                                {
                                    rooms.RemoveAt(i);
                                    found = true;
                                    break;
                                }

                            }
                            if (!found)
                            {
                                Console.WriteLine("Помещения с таким названием нет\n");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Нет созданных помещений \n");
                            Console.ReadLine();
                        }
                        
                        break;
                        #endregion
                    case 3:
                        #region если выбрали Добавить устройство
                        Console.Clear();
                        if (rooms.Count > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Добавить устройство...");

                            Console.Write("Введите название помещения (список доступных помещений - ");
                            foreach (var item in rooms)
                            {
                                Console.Write(item.Name + ", ");
                            }
                            Console.Write("\b\b): ");
                            bool check=false;
                            string nameOfRoom = Console.ReadLine();
                            for (int i = 0; i < rooms.Count; i++)
                            {
                                if (rooms[i].Name==nameOfRoom)
                                {
                                    check = true;
                                }
                            }
                            if(check)
                            {
                                Console.Write("Введите название устройства ");
                                Console.Write("(список устройств в помещении - ");

                                #region выводит список устройств в помещении
                                for (int i = 0; i < rooms.Count; i++)
                                {
                                    if (rooms[i].Name == nameOfRoom)
                                    {
                                        if (rooms[i].CountOfDevisesInList() > 0)
                                        {
                                            for (int j = 0; j < rooms[i].CountOfDevisesInList(); j++)
                                            {
                                                Console.Write(rooms[i].GetDeviceFromList(j).Name);
                                                Console.Write(", ");
                                            }
                                            Console.Write("\b\b  \b\b");
                                        }
                                        else
                                        {
                                            Console.Write("0");
                                        }

                                        break;
                                    }
                                }
                                #endregion

                                Console.Write("): ");
                                string nameOfDevice = Console.ReadLine();

                                for (int i = 0; i < rooms.Count; i++)
                                {
                                    if (rooms[i].Name == nameOfRoom)
                                    {
                                        rooms[i].AddDeviceToList(new Device { Name = nameOfDevice, State = false });
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("такого помещения нету");
                                Console.ReadLine();
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Сначала добавьте помещение. Помещений : 0\n");
                            Console.ReadLine();
                        }
                        
                        break;
                        #endregion
                    case 4:
                        #region если выбрали Удалить устройство
                        Console.Clear();
                        if (rooms.Count > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Удалить устройство...");

                            Console.Write("Введите название помещения (список доступных помещений - ");
                            foreach (var item in rooms)
                            {
                                Console.Write(item.Name + ", ");
                            }
                            Console.Write("\b\b): ");

                            string nameOfRoom = Console.ReadLine();
                            Console.Write("Введите название устройства ");
                            Console.Write("(список устройств в помещении - ");

                            for (int i = 0; i < rooms.Count; i++)
                            {
                                if (rooms[i].Name == nameOfRoom)
                                {
                                    if (rooms[i].isEmptyListOfDevises())
                                    {
                                        Console.Write("0): ");
                                        break;
                                    }
                                    else
                                    {
                                        for (int k = 0; k < rooms.Count; k++)
                                        {
                                            if (rooms[k].Name == nameOfRoom)
                                            {
                                                for (int j = 0; j < rooms[i].CountOfDevisesInList(); j++)
                                                {
                                                    Console.Write(rooms[i].GetDeviceFromList(j).Name);
                                                    Console.Write(", ");
                                                }

                                                Console.Write("\b\b  \b\b");
                                            }
                                        }
                                        Console.Write("): ");

                                        string nameOfDevice = Console.ReadLine();
                                        for (int k = 0; k < rooms.Count; k++)
                                        {
                                            if (rooms[k].Name == nameOfRoom)
                                            {
                                                for (int j = 0; j < rooms[k].CountOfDevisesInList(); j++)
                                                {
                                                    if (rooms[k].GetDeviceFromList(j).Name == nameOfDevice)
                                                    {
                                                        rooms[k].DeleteDevice(j);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Сначала добавьте помещение. Помещений 0\n");
                            Console.ReadLine();
                        }
                        
                        break;
                        #endregion
                    case 5:
                        #region если выбрали Список помещений
                        Console.Clear();
                        if (rooms.Count > 0) 
                        {
                            #region если есть помещения
                            while (true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("----------------"); 
                                for (int i = 0; i < rooms.Count; i++)
                                    Console.WriteLine("{0} {1}", i + 1, rooms[i].Name);

                                Console.WriteLine("0 - back\n");

                                Console.Write("Выберите помещение: ");

                                bool result = int.TryParse(Console.ReadLine(), out menu);

                       
                                if (menu == 0)
                                {
                                    Console.WriteLine();
                                    break;
                                }

                                if (menu <= rooms.Count && menu > 0)
                                    if (rooms[menu - 1].CountOfDevisesInList() > 0) 
                                    {
                                        #region если есть устройства в помещени
                                        while (true)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("----------------"); 
                                            for (int i = 0; i < rooms[menu - 1].CountOfDevisesInList(); i++)
                                            {
                                                Console.WriteLine("{0} {1}", i + 1, rooms[menu - 1].GetDeviceFromList(i).Name);

                                            }
                                            Console.WriteLine("0 back\n");

                                            Console.Write("Выберите устройство: ");

                                            int menu2;
                                            result = int.TryParse(Console.ReadLine(), out menu2);

                                        
                                            if (menu2 == 0)
                                            {
                                                break;
                                               
                                            }
                                                
                                            while (true)
                                            {
                                                Console.WriteLine("1-включить\n2-выключить\n0-назад\n");

                                                if (rooms[menu - 1].GetDeviceFromList(menu2 - 1).State == false)
                                                {
                                                    Console.WriteLine("Устройство выключено");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Устройство включено");
                                                }

                                                int menu3;
                                                result = int.TryParse(Console.ReadLine(), out menu3);

                                               
                                                if (menu3 == 0)
                                                    break;
                                                    
                                                
                                                
                                                
                                    
                                                if (menu3 == 1 || menu3 == 2)
                                                {
                                                    if (menu3 == 1)
                                                    {
                                                        rooms[menu - 1].GetDeviceFromList(menu2 - 1).SwitchOn();
                                                    }
                                                    else if (menu3 == 2)
                                                    {
                                                        rooms[menu - 1].GetDeviceFromList(menu2 - 1).SwitchOff();
                                                    }
                                                }
                                                else
	                                            {
                                                    Console.WriteLine("Некорректный ввод\n");
                                                    Console.ReadLine();
                                                }
                                                
                                            }
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        Console.WriteLine("Устройств в помещении - 0\n");
                                        Console.ReadLine();
                                    }
                                else
                                    Console.WriteLine("Некорректный ввод\n");
                                    Console.ReadLine();
                            }
                            #endregion
                        }
                        else
                        {
                            Console.WriteLine("Помещений 0\n");
                            Console.ReadLine();
                        }

                        break;

                        #endregion
                }
            }
        }
    }
}