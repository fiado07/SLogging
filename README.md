# SLog

#### SLog is light way tool to log data into database(sql server and mysql) and to file.

## Support

- Sql Server
- MySql

## How to use:

Create instance of db provider as shown bellow.

```c#
public class SqlServerContext
  {
 
      public readonly IDbConnection SqlContext;
 
      public SqlServerContext()
      {
 
          SqlContext = new SqlConnection( @"Persist Security Info = False; Integrated Security = true; Initial Catalog =; server = ");
 
      }
 
  }
```

## Log initializer

```c#
Log log;
Person person;
 
public TestSLog()
 {
 
   log = Log.GetLog(new SqlServerContext().SqlContext, @"c:\dir\");
   
 }
```



## Log to db and file

#### Info

```c#
public void Log_info_Object()
 {
 
   person = new Person { Name = "Name", Age = 2 };
  
    // simple log
  	log.Info("x120801", "inf", Common.LogAppender.all);
 
  	// log with extra data
  	log.Info(person, "x120801", "inf", Common.LogAppender.all);

 }
```

#### Debug

```c#
public void Log_debug()
{
 
	person = new Person { Name = "Name", Age = 2 };
  
	// simple log
	log.Debug("x120801", "debug", new Exception("error"), Common.LogAppender.all);
 
	// log with extra data
	log.Debug(person, "x120801", "debug", new Exception("error"), Common.LogAppender.all);
 
}
```

#### Error

```c#
public void Log_Error()
{
 
	// simple log
	log.Error("x120801", "info", new Exception("error"), Common.LogAppender.all);
 
	// log with extra data
	log.Error(person, "x120801", "info", new Exception("error"), Common.LogAppender.all);

}
```