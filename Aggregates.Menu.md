# Domain Models

## Menu

```csharp

class Menu
{
	Menu Create();
	void AddDinner(Dinner dinner);
	void RemoveDinner(Dinner dinner);
	void UpdateSection(MenuSection section);
}
```

```json
{
	"id":"00000-00000-0000",
	"name":"Yummy menu",
	"description": "A menu with yummy food",
	"averageRating": 4.5,
	"sections":[
		{
		"id":"00000-00000-0000",
		"name":"Fried Pickles",
		"description": "Deep Fried Pickles",
		"price":5.99
		}
	],
	"createdDateTime":"2020-01-01T00:00:00.00000Z"
	"updatedDateTime":"2020-01-01T00:00:00.00000Z"
	"hostId":"00000-00000-0000",
	"dinnerIds":["00000-00000-0000","00000-00000-0000"],
	"menuReviewIds":["00000-00000-0000","00000-00000-0000"],

}

```