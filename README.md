**ObjectPool: шаблон проектирования для эффективного управления объектами в Unity**

**Цель**

Этот проект предоставляет реализацию шаблона проектирования ObjectPool на C# для Unity, помогая разработчикам создавать и управлять пулами объектов, уменьшая количество выделений и сборов мусора в играх.

**Описание шаблона проектирования**

ObjectPool - это шаблон проектирования, который создает и управляет пулом предварительно созданных объектов, которые могут быть использованы и возвращены в пул по мере необходимости. Он помогает оптимизировать производительность, уменьшая затраты на создание и уничтожение объектов во время выполнения игры.

**Основные особенности**

* **Уменьшение выделений и сборов мусора:** предварительное создание и повторное использование объектов из пула значительно снижает нагрузку на сборщик мусора и повышает производительность игры.
* **Конфигурируемые размеры пула:** вы можете настроить начальный и максимальный размеры пула для каждого типа объекта.
* **Простая интеграция:** простая в использовании система API, которая позволяет легко интегрировать пулы объектов в ваши скрипты Unity.

**Использование**

Для использования ObjectPool просто создайте экземпляр пула для каждого типа объекта, который вы хотите кэшировать. Затем вы можете создавать объекты из пула с помощью метода Get() и возвращать их в пул с помощью метода Return().

Пример использования

```
// Создание пула объектов
ObjectPool<Projectile> projectilePool = new ObjectPool<Projectile>(projectilePrefab, transform, 10, true);

// Получение из пула
Projectile projectile = projectilePool.GetFree(();

// Использование снаряда в игре

// Возврат снаряда в пул
projectilePool.Return(projectile);
```
