# GPPlayerDataStorage

Утилита для продвинутого взаимодействия с хранилищем данных игрока в [GamePush](https://gamepush.com/).

Предоставляет универсальное, типобезопасное и гибкое решение для работы с данными игрока, такими как `bool`, `int`, `float` и `string`. 
Библиотека использует фабричный паттерн, абстракции и внедрение зависимостей для разделения логики и повышения модульности - что позволяет использовать решения и с другими хранилищами.

## Ключевые особенности
 - Автоматическое взаимодействие с хранилищем при:
    - инициализации (получение данных)
    - изменении (запись данных и синхронизация)
 - Обращение к данным из хранилища, как к обычным свойствам
 - Готовая абстракция для других интеграций

## Пример использвания

```c#
// Создаём экземпляр фабрики для интеграции с GP_Player
var factory = new GPPlayerIntegrationFactory();

// Создаём свойства через фабрику
var boolProperty = PlayerDataPropertyFactory.Create<bool>("is_user_active", factory);
var intProperty = PlayerDataPropertyFactory.Create<int>("player_score", factory);
var floatProperty = PlayerDataPropertyFactory.Create<float>("player_speed", factory);
var stringProperty = PlayerDataPropertyFactory.Create<string>("player_name", factory);

// Работа со свойствами
boolProperty.Value = true; // Присваиваем значение
intProperty.Value += 10;   // Увеличиваем значение
stringProperty.Value = "Player1"; // Присваиваем строку

// Благодаря implicit-операторам можно обращаться напрямую
if (boolProperty) Debug.Log("Игрок активен");
int totalScore = intProperty; // Получаем значение
```

## Ссылки

 - [Скачать Unity-пакетом](GPPlayerDataStorage/Release/gpplayerdatastorage.unitypackage)

## Лицензия

Данный проект распространяется под лицензией [MIT](LICENSE). Вы можете свободно использовать, модифицировать и распространять этот проект с обязательным указанием лицензии в вашем проекте.