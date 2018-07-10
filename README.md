# CSVWorker
Based on a few issues I had at work, I needed to parse different CSVs and comapring the values. Few months later the client come and say the structure of the CSV changed completly, plus more clients require this service I've been forced to write something more efficient and reusable.

Thats the main reason why i started to write this library. Allow to read and write CSV files dinamically.
the library runs on `.NET Standard 2.0`

# Getting Started
- Import the library into your code
- Available on 
1. TODO
2. TODO

## Reader
- To read a CSV you can either use a class or a `dynamic` object:

#### 1. Declaration
1.1. Dynamic object
```
private CsvReader<dynamic> Csv { get; set; }
Csv = new CsvReader<dynamic>(@"path", "file.csv");
```
1.2. Class 
```
private CsvReader<foo> Csv { get; set; }
Csv = new CsvReader<foo>(@"path\file.csv");
```

#### 2. Configuration
2.1. Delimiter  
- `Csv.Configuration.SetDelimiter(';');`

2.2. Qualified text "inquotes"
- `Csv.Configuration.SetQualifiedText('"');`

2.3.  If the file contains headers
- `Csv.Configuration.SetContainsHeaders(false);`

#### 3 Mapping
3.1. By default if you used a class in the creation of the object, the code will map the properties to the header names. But if you have different names you can create the mapping.
```
 public DateTime Date { get; set; }
 var Csv = new CsvReader<foo>(@"path\file.csv");
 Csv.Map("bar", a => a.Date);
```
you can also use index for the mapping
```
 Csv.Map(1, a => a.Date);
```

3.2. Format 
 If a property of you class is certain kind of object you can define the format which is into the csv to read it correctly
```
 public DateTime bar { get; set; }
 var Csv = new CsvReader<foo>(@"path\file.csv");
 Csv.Map("bar", a => a.bar).Format("dd/MM/yy");
```
3.3. Cultureinfo
Different countries has different type wrinting style, for example decimal places are sometimes marked as '.' and in other places as ',' to fix this issue, `Cultureinfo` is your firend.
```
Csv.Map("bar", a => a.bar).Format(new CultureInfo("en-IE"));
```
3.4. Combine both
```
Csv.Map("Date", a => a.Date).Format("dd/MM/yy", new CultureInfo("en-IE"));
```

#### 4 Filtering
4.1. CSV filtering
- This filter acts on the CSV 

4.1.1 By header
- `var filteredRows = Csv.Rows.Where(a => a["foo"] == "bar")`

4.1.2 By index
- `var filteredRows = Csv.Rows.Where(a => a[1] == "bar")`

4.2 Class filtering
- ` var filteredRows = Csv.Read().Where(a => a.foo == "bar");`


#### 5. Read the file
- The file is atumatically readed when you call `Csv.Rows` or you call `Csv.Read()`

`Csv.Read()` will return you a `List<T>`



## Writer
#### 1.  Declaration
```
private CsvWriter<foo> Csv { get; set; }
Csv = new CsvWriter<Insurance>();
```
#### 2. Mapping
2.1 Relate fields
- `Csv.Map(a => a.foo, "column1");`

2.2 Visibility

By default a property will be visible.
- `Csv.Map(a => a.foo, "column1").Visible(true);`

2.3 Format
- TODO

2.4 Position
- TODO
2.5 HeaderName
- TODO

#### 3. Configuration
3.1. Create directory
- sometimes the directory you want to write does not exist, if you want to force the code to create you need to set one of the next:
```
Csv.Configuration.SetCreateDirectory(false);
Csv.Configuration.CreateDirectory = true;
```
3.2. Empty file extension
- If you want to add an especial extension if the list to write into the file is empty
```
Csv.Configuration.EmptyFilesExtension = ".empty";
Csv.Configuration.SetEmptyFilesExtension(".empty");

```



#### 4. Write

```
 private List<foo> _foolist;
 Csv.Write(_foolist, @"c:\temp\foofile.csv");
```


## Dependencies
- `Microsoft.CSharp`

# Contribute
The code is under the MIT license, and everyone is welcome to contribute on it.
