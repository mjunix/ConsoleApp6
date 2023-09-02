# Get started
1. Clone this repo.
2. Open "ConsoleApp6.sln" in Visual Studio 2022 Community Edition.
3. Build and run the application. The application is a console application that will read from stdin and print to stdout.

The application will read two lines from stdin and then print the result:
* The first line is 4 integers (widht, height, X, Y).
* The second line should contain the commands to be executed.

Example (input in bold, output in non-bold):
<pre>
<code>
<b>4,4,2,2</b>
<b>1,4,1,3,2,3,2,4,1,0</b>
[0, 1]
</code>
</pre>

# Run tests
In Visual Studio, choose menu item `Test` then `Run All Tests`.

# Generate (HTML) code coverage report
In Visual Studio, in the `Solution Explorer` right-click `TestProject1` and choose `Open in Terminal`.
In the terminal first run:
```
dotnet tool restore
```
You only need to run the above command once after having cloned the repository.

Then, every time you want to generate a code coverage report first run the tests by running the following command (in a terminal inside `TestProject1`):
```
dotnet test --collect:"XPlat Code Coverage"
```
This will generate the file `coverage.cobertura.xml` inside a folder called `TestResults`, eg. `TestResults\f3cd7e40-3977-4fcb-bb90-13efb987feb5\coverage.cobertura.xml`.

Now run the following command to generate the HTML report, be sure to change `{...GUID...}` in the command below so the filepath correctly points to your `coverage.cobertura.xml`-file:
```
dotnet tool run reportgenerator reportgenerator -targetdir:"coveragereport" -reporttypes:Html -classfilters:-ClassLibrary1.InvalidPositionException -reports:".\TestResults\{...GUID...}\coverage.cobertura.xml"
```
This will generate the HTML report inside the folder `coveragereport`, inside that folder open the `index.html` file in your browser to see the code coverage report.
