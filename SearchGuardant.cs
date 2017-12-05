using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardant;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    class SearchGuardant
    {
        /* Начало. Блок переменных для работы с Guardant API */
        GrdE RetCode;                       // Код ошибки для всех методов Guardant API
        Handle GrdHandle = new Handle();    // Создает пустой хэндл для контейнера Guardant

        static uint CryptPU = 0x8566783U;         // Константы для шифрования кодов
        static uint CryptRD = 0x17d49c84U;        // доступа к ключу защиты
                                                  //  GrdDC.DEMONVK = "2474964803";

        // Шифруем демонстрационные коды доступа, вычитая из них случайные числа для 
        // обеспечения более высокой степени взломоучтойчивости
        uint PublicCode = Convert.ToUInt32("2474964803") - CryptPU;    // Не должно быть в открытом виде        
        uint ReadCode = Convert.ToUInt32("1607945334") - CryptRD;    // Не должно быть в открытом виде 

        // Переменные используются при вызове метода GrdSetFindMode()

        uint DongleID = 0;       // ID ключа (Номер ключа)


        FindInfo GrdFindInfo1 = new FindInfo();   // структура используемая в методе GrdFind()
        FindInfo GrdFindInfo2 = new FindInfo();   // структура используемая в методе GrdFind()

        // переменные для GrdWrite() и GrdRead()

        Byte[] TempData = new Byte[52]; // Временные данные для работы с методом GrdRead
        Byte[] PIData = new Byte[32];   // Переменная для работы с защищенным ячейками

        /* Конец. Блок переменных для работы с Guardant API */
        public SearchGuardant(ref bool searchKeyNotFound)
        {
            RetCode = GrdApi.GrdStartup(GrdFMR.Local);
            ErrorHandling(GrdHandle, RetCode);
            GrdHandle = GrdApi.GrdCreateHandle(GrdCHM.MultiThread);
            if (GrdHandle.Address == 0) // Если найдена ошибка
            {
                ErrorHandling(new Handle(0), GrdE.MemoryAllocation);
            }
            RetCode = GrdApi.GrdSetAccessCodes(GrdHandle,   // хэндл контейнера Guardant 
               PublicCode + CryptPU,   // Публичный код. Используется для поиска ключа. Должен быть установлен
               ReadCode + CryptRD,     // Приватный код для чтения; Данный код используется для чтения незащищенных ячеек памяти;
               0,   // Приватный код для записи. В большинстве случаев, он не нужен. Старайтесь не включать его в итоговые версии приложения.
               0);  // Мастер код. Используется для редактирования параметров ключа. Никогда не вставляйте этот код в публичные версии приложения!
            ErrorHandling(GrdHandle, RetCode); // Обработка ошибок
            int donglefindcount = 0;
            // -----------------------------------------------------------------
            // Поиск всех ключей и вывод их ID
            // -----------------------------------------------------------------
            RetCode = GrdApi.GrdFind(GrdHandle, GrdF.First, out DongleID, out GrdFindInfo1);
            while (RetCode == GrdE.OK)
            {
                // Увеличиваем счетчик ключей на 1
                donglefindcount++;
                // Выводим ID всех ключей
                //MessageBox.Show("ID " + Convert.ToString(donglefindcount) + "-го ключа: " + Convert.ToString(DongleID), "Поиск ключей");
                // Поиск следующего ключа
                RetCode = GrdApi.GrdFind(GrdHandle, GrdF.Next, out DongleID, out GrdFindInfo2);
            }
            if (RetCode == GrdE.AllDonglesFound) { }
             //   MessageBox.Show("Поиск ключей завершен");
            else
                ErrorHandling(GrdHandle, RetCode);
            if (donglefindcount == 0)
            { // Если ни один ключ не найден, выводим ошибку и закрываем программу
                MessageBox.Show("Ни одного ключа защиты Guardant не найдено! Вставьте ключ.", "Поиск ключей");
                searchKeyNotFound = false;
               // Application.Exit(); // Завершаем программу
            }
            else
            {   // Выводим подробную информацию о первом найденном ключе из структуры GrdFindInfo1
                /* MessageBox.Show(
                     "Подробная информация о первом найденном ключе: " + (char)10 + (char)13 +
                     "ID ключа = " + Convert.ToString(GrdFindInfo1.dwID) + (char)10 + (char)13 +
                     "Публичный код = 0x" + GrdFindInfo1.dwPublicCode.ToString("X") + (char)10 + (char)13 +
                     "Версия прошивки = " + Convert.ToString(GrdFindInfo1.byHrwVersion) + (char)10 + (char)13 +
                     "Ресурс сетевого ключа (макс) = " + Convert.ToString(GrdFindInfo1.byMaxNetRes) + (char)10 + (char)13 +
                     "Тип ключа = " + GrdFindInfo1.wType.ToString("X") + (char)10 + (char)13 +
                     "Номер программы = " + Convert.ToString(GrdFindInfo1.byNProg) + (char)10 + (char)13 +
                     "Версия программы = " + Convert.ToString(GrdFindInfo1.byVer) + (char)10 + (char)13 +
                     "Серийный номер = " + Convert.ToString(GrdFindInfo1.wSN) + (char)10 + (char)13 +
                     "Битовая маска  = " + Convert.ToString(GrdFindInfo1.wMask) + (char)10 + (char)13 +
                     "Счетчик  = " + Convert.ToString(GrdFindInfo1.wGP) + (char)10 + (char)13 +
                     "Реальный сетевой ресурс =  " + Convert.ToString(GrdFindInfo1.wRealNetRes) + (char)10 + (char)13 +
                     "Индекс = " + Convert.ToString(GrdFindInfo1.dwIndex)
                 , "Информация о ключе");*/
                searchKeyNotFound = true;
            }
        }

        private static GrdE ErrorHandling(Handle hGrd, GrdE nRet)
        {
            if (nRet != GrdE.OK)
            {
                // Выводим ошибку последнего вызванного метода
                MessageBox.Show(GrdApi.PrintResult((int)nRet), "Ошибка");

                if (hGrd.Address != 0)	// Проверяем существует ли хэндл контейнера Guardant 
                {
                    // Закрываем хэндл, выходим с сервера ключа,  освобождаем память
                    nRet = GrdApi.GrdCloseHandle(hGrd);
                }

                // Деинициализация копии Guardant API. Функция GrdCleanup() должна быть вызвана перед закрытием программы
                nRet = GrdApi.GrdCleanup();

                // Выход из приложения
                Environment.Exit((int)nRet);
            }
            return nRet;
        }
    }
}
