## Это выполненное мной тестовое задание на позицию джуна от компании ProSpace.

- Backend: .NET Core 8, ASP.NET Core, Entity Framework, база данных PostgreSQL, внедрен Swagger, авторизация и аутентификация через JWT-токены;
- Frontend: одностраничное веб-приложение (SPA), выполненное на Vue3 последней версии (HTML, JavaScript);
- Фронтенд вместе с базой данных можно запустить в Docker через docker-compose, фронтенд запускается отдельно из IDE.
_______________________________________________________________________________________________________________________________________________________________

## Функционал системы
  
В системе есть 2 роли:
1.	Роль заказчика
2.	Роль менеджера

Роль менеджера

1.	Добавление, редактирование и удаление товаров
2.	Добавление, редактирование и удаление пользователей
3.	Подтверждение заказа. Устанавливается дата доставки и статус в Выполняется.
4.	Закрытие заказа. Устанавливает статус Выполнен.

Роль Заказчика

1.	Просмотр каталога товаров.
2.	Набирание товаров в корзину
3.	Подача заказа товаров. Устанавливается дата создания и статус в Новый.
4.	Просмотр статуса заказов. Фильтр по статусу.
5.	Удаление заказа. Возможно до статуса Выполняется.

_______________________________________________________________________________________________________________________________________________________________

P.S. в задании было указано сделать приложение со стилями, с определенным интерфейсом. 
Но, к сожалению, времени у меня не хватило, поэтому приложение функционально по всем указанным в заданиии видам взаимодействия, но без стилей 
(со стилем отображается только таблица для наглядности).
