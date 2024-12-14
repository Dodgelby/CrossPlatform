﻿using Lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Lab1;
using Lab2;
using Lab3;
using System.Text;
using ClassLibraryLab3;


namespace Lab.Controllers
{
    public class LabController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public LabController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Lab_1()
        {
            var model = new LabViewModel
            {
                TaskNumber = "1",
                TaskVariant = "3",
                TaskDescription = "Знайдіть кількість невироджених прямокутників зі сторонами, паралельними осям координат, вершини яких лежать у точках із цілими координатами всередині або на межі прямокутника, протилежні кути якого знаходяться у точках (0, 0) та (W, Н).",
                InputDescription = "Вхідний файл INPUT.TXT містить два натуральні числа W і Н, що не перевищують 1000.",
                OutputDescription = "У вихідний файл OUTPUT.TXT виведіть відповідь на завдання.",
                TestCases = new List<TestCase>
            {
                new TestCase { Input = "1 1", Output = "1" },
                new TestCase { Input = "2 1", Output = "3" },
            }
            };
            return View(model);
        }

        public IActionResult Lab_2()
        {
            var model = new LabViewModel
            {
                TaskNumber = "2",
                TaskVariant = "3",
                TaskDescription = "- Ти брешеш, Колю! На Марсі життя немає! Хто тобі таку нісенітницю сказав?\r\n" +
                "- Петя. А йому сказав Сашко.\r\n" +
                "- Та від Петі я в житті правдивого слова не чув! Йому що не скажуть, він усе переверне. Та й Сашка звідки знати?\r\n" +
                "- А Саші розповів про це Володимир Олексійович, наш учитель біології.\r\n" +
                "- Ну, Володимиру Олексійовичу можна вірити... Тільки навряд чи він так сказав, це або Сашко, або Петя придумав. А може, це ти мене розігруєш?\r\n" +
                "- Хвилинку, хлопці, - втрутився Гліб Тимофійович, який підійшов до вчителів математики, - давайте підійдемо до проблеми формально. Припустимо, що всі діалоги – Володимира Олексійовича з Сашком, Сашка з Петею та Петі з Колею – справді мали місце. Пронумеруємо хлопців числами 1, 2 і 3. " +
                "Припустимо також, що кожен із хлопців незалежно один від одного передав отриману інформацію щодо життя на Марсі правильно з ймовірністю pi, а збрехав з ймовірністю qi = 1 - pi для i = 1, 2, 3. Імовірності - це речові числа від нуля до одиниці; подія, що має ймовірність 0, ніколи не відбудеться, подія ж з ймовірністю 1 відбудеться без жодного сумніву. " +
                "Знаючи, що Коля після цього оголосив, що життя на Марсі таки є, знайдіть за даними pi ймовірність того, що так дійсно сказав Володимир Олексійович.\r\n– А як шукати цю ймовірність? І що означає незалежно один від одного? - Розгубилися хлопці.\r\n- Незалежність означає, що дія одного з хлопців ніяк не відбивається на тому, як надійдуть інші. Наприклад, Пете неважливо, чи збрехав Сашко - у будь-якому випадку він передасть сказане Сашком правильно з ймовірністю рівно p2. Завдання нескладне, і можна розглянути всі вісім можливих випадків. " +
                "Перший випадок – всі хлопці говорили правду, і ймовірність цього випадку дорівнює p1∙p2∙p3. В цьому випадку життя на Марсі, без сумніву, є – Володимиру Олексійовичу ми віримо, а хлопці передали його слова правильно. Другий випадок, коли збрехав лише Сашко, має місце з ймовірністю q1∙p2∙p3, і в цьому випадку життя на Марсі немає. Далі переберемо решту шести випадків, щоразу перемножуючи відповідні ймовірності, а потім підсумуємо ймовірності тих випадків, у яких слова вчителя передані правильно. Те, що ймовірності окремих хлопців у кожному разі треба перемножити - і є формальне визначення незалежності. Ну, у яких випадках буде передано саме те, що говорив Володимир Олексійович?\r\n" +
                "- В одному …\r\n- А ось і ні. Наприклад, якщо Петя та Коля збрехали, а Сашко сказав правду, то істина, двічі спотворившись, дійде до нас у незмінному вигляді. І взагалі, парна кількість заперечень, застосованих до твердження, дає саме твердження. У нашій задачі випадків з парною кількістю заперечень - чотири, і підсумкова ймовірність дорівнює p1∙p2∙p3+q1∙q2∙p3+q1∙p2∙q3+p1∙q2∙q3.\r\n- Тобто якщо Петя і Коля точно збреше, а Сашко точно скаже правду, то від Коли ми почуємо точно те, що казав вчитель?\r\n- Абсолютно вірно. А тепер розв'яжіть завдання для загального випадку, коли хлопців не троє, а n. Першому, хто вирішить – п'ятірка на наступній контрольній!\r\n",
                InputDescription = "Вхідний файл INPUT.TXT містить ціле число n (1 ≤ n ≤ 100). У другому рядку через пропуск записані n дійсних чисел - це числа p1, p2, ..., pn (0 ≤ pi ≤ 1). Числа дані з не більше ніж шістьма десятковими знаками після коми.",
                OutputDescription = "У вихідний файл OUTPUT.TXT виведіть одне речове число, округлене до шести знаків після коми - ймовірність існування життя на Марсі.",
                TestCases = new List<TestCase>
            {
                new TestCase { Input = "3\n1 0,1 0,9", Output = "0,18" },
            }
            };
            return View(model);
        }

        public IActionResult Lab_3()
        {
            var model = new LabViewModel
            {
                TaskNumber = "3",
                TaskVariant = "3",
                TaskDescription = "У міському управлінні міліції одного прибережного міста ведеться розслідування великої справи, в якій можуть бути замішані працівники міліції. Було ухвалено рішення про таємну установку обладнання для перегляду інформації, що надходить через Інтернет. " +
                "Під підозру потрапляють два відділи, але виділити гроші на купівлю двох комплектів обладнання не вдалося. На щастя, внутрішня мережа управління має деревоподібну структуру, тобто кожен відділ має вихід в Інтернет через якийсь інший відділ. Виняток становить відділ боротьби з комп'ютерними злочинами, який має безпосередній доступ до Інтернету по модемній лінії.\r\n" +
                "Можна було б встановити обладнання для стеження прямо в цьому відділі, але для запобігання зловживанням краще знайти таке розташування, щоб порушувалася секретність якомога меншої кількості зайвих відділів.\r\nЯк найдосвідченішому в подібних питаннях співробітнику, вирішення цього завдання доручили вам. Підлеглі вже пронумерували всі відділи натуральними числами, починаючи з першого, перший номер присвоєно відділу боротьби з комп'ютерними злочинами.\r\n",
                InputDescription = "Перший рядок вхідного файлу INPUT.TXT містить натуральне число N (N ≤ 30000) – кількість відділів. У другому рядку записано номери двох відділів, за якими необхідно встановити стеження. На третьому рядку знаходяться n-1 натуральних чисел, i-е їх не більше i і задає номер відділу, до якого приєднаний відділ i + 1.",
                OutputDescription = "У вихідний файл OUTPUT.TXT виведіть одне число – номер відділу, в якому слід встановити обладнання, що слідкує.",
                TestCases = new List<TestCase>
            {
                new TestCase
                {
                    Input = "4\r\n3 4\r\n1 1 3",
                    Output = "3"
                },
                 new TestCase
                {
                    Input = "8\r\n3 6\r\n1 1 2 4 5 1 1",
                    Output = "1"
                }
            }
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessLab(int labNumber, IFormFile inputFile)
        {
            if (inputFile == null || inputFile.Length == 0)
                return BadRequest("Please upload a file");

            // Read file contents into a string array
            string[] lines;
            using (var reader = new StreamReader(inputFile.OpenReadStream()))
            {
                var fileContent = await reader.ReadToEndAsync();
                lines = fileContent.Split(Environment.NewLine); // Split into lines
            }

            string tempFilePath = Path.GetTempFileName();

            using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                await inputFile.CopyToAsync(stream);
            }

            // Variable to store the processed result
            string output = null;
            StringBuilder result = new StringBuilder();

            // Execute the lab processing method based on lab number
            switch (labNumber)
            {
                case 1:
                    // Variables for input
                    int W, H;

                    Lab1.Program.ReadInput(out W, out H, tempFilePath);

                    // Process the task
                    long _result = Lab1.Program.CountNonDegenerateRectangles(W, H);

                    output = _result.ToString();
                    break;
                case 2:
                    output = Lab2.Program.Process(lines).ToString();
                    break;
                case 3:
                    output = TaskProcessor.ProcessTask(lines);
                    break;
                default:
                    return BadRequest("Invalid lab number");
            }

            // Return result as JSON
            var result_ = new { output = output };
            return Json(result_);
        }

    }
}