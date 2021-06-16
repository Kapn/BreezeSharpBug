# BreezeSharpBug

This is a copy of one of BreezeSharp's example projects, tweaked slightly to show an error that occurs when attempting to query for a modified entity.

## Directories

NorthwindClient
- Simple console Breeze# app

NorthwindCore3
- Server application

## Steps to Setup and Reproduce

1. Create an empty MSSQL database named 'Northwind'
2. Run the model, and then data, sql scripts located in `/dbscripts`
3. Update connection string for NorthwindCore3 in NorthwindServer/appsettings.json. 
4. Run Server
5. Run Client

When querying for an entity and expanding its parent, if the parent has been modified, breezesharp throws a null reference error in `Breeze.Sharp.JsonEntityConverter.ParseObject` because `backingStore` is null.


### StackTrace:
```
 at Breeze.Sharp.JsonEntityConverter.<>c__DisplayClass6_0.<ParseObject>b__0(KeyValuePair`2 kvp)
   at Breeze.Sharp.Core.EnumerableFns.ForEach[T](IEnumerable`1 items, Action`1 action)
   at Breeze.Sharp.JsonEntityConverter.ParseObject(NodeContext nodeContext, EntityAspect targetAspect)
   at Breeze.Sharp.JsonEntityConverter.PopulateEntity(NodeContext nodeContext, IEntity entity)
   at Breeze.Sharp.JsonEntityConverter.CreateAndPopulate(NodeContext nodeContext)
   at Breeze.Sharp.JsonEntityConverter.<>c__DisplayClass6_0.<ParseObject>b__0(KeyValuePair`2 kvp)
   at Breeze.Sharp.Core.EnumerableFns.ForEach[T](IEnumerable`1 items, Action`1 action)
   at Breeze.Sharp.JsonEntityConverter.ParseObject(NodeContext nodeContext, EntityAspect targetAspect)
   at Breeze.Sharp.JsonEntityConverter.PopulateEntity(NodeContext nodeContext, IEntity entity)
   at Breeze.Sharp.JsonEntityConverter.CreateAndPopulate(NodeContext nodeContext)
   at Breeze.Sharp.JsonEntityConverter.ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.DeserializeConvertable(JsonConverter converter, JsonReader reader, Type objectType, Object existingValue)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.PopulateList(IList list, JsonReader reader, JsonArrayContract contract, JsonProperty containerProperty, String id)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.CreateList(JsonReader reader, Type objectType, JsonContract contract, JsonProperty member, Object existingValue, String id)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.CreateValueInternal(JsonReader reader, Type objectType, JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerMember, Object existingValue)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.SetPropertyValue(JsonProperty property, JsonConverter propertyConverter, JsonContainerContract containerContract, JsonProperty containerProperty, JsonReader reader, Object target)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.PopulateObject(Object newObject, JsonReader reader, JsonObjectContract contract, JsonProperty member, String id)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.CreateObject(JsonReader reader, Type objectType, JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerMember, Object existingValue)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.CreateValueInternal(JsonReader reader, Type objectType, JsonContract contract, JsonProperty member, JsonContainerContract containerContract, JsonProperty containerMember, Object existingValue)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalReader.Deserialize(JsonReader reader, Type objectType, Boolean checkAdditionalContent)
   at Newtonsoft.Json.JsonSerializer.DeserializeInternal(JsonReader reader, Type objectType)
   at Breeze.Sharp.EntityManager.<ExecuteQuery>d__42.MoveNext()
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Breeze.Sharp.EntityManager.<ExecuteQuery>d__39`1.MoveNext()
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
   at NorthwindClient.Program.<Main>d__0.MoveNext() in C:\Users\kapan\Desktop\NorthwindCore\NorthwindClient\NorthwindClient\Program.cs:line 35
```
