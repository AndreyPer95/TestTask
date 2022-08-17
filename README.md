# TestTask1
  Написать на C# утилиту, которая мониторит процессы Windows и "убивает" те процессы, которые работают слишком долго. 

- На входе три параметра: название процесса, допустимое время жизни (в минутах) и частота проверки (в минутах). 

- Утилита запускается из командной строки. При старте она считывает три входных параметра и начинает мониторить процессы с указанной частотой. Если процесс живет слишком долго – завершает его и выдает сообщение в лог. 

Пример запуска: 

monitor.exe notepad 5 1 

С такими параметрами утилита раз в минуту проверяет, не живет ли процесс notepad больше пяти минут, и "убивает" его, если живет. 
