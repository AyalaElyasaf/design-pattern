Console.WriteLine("begin!!!!!!!!!!");

// user
User studentUser = new("ayala", "ayala767@GMAIL.COM", "12345");
User teacherUser = new("shani", "shani585@GMAIL.COM", "654654");

// repos
Repository angular = new("angular project", "recipe book application");
Repository server = new("server project", "project in web API");
Repository designPattern = new("designPattern project", "hard project of simulation in git");
Repository python = new("python project", "amazing project in python");

// branches
Branch branch1 = new("start angular project", angular);
Branch branch2 = new("start server project", server);
Branch branch3 = new("start designPattern project", designPattern);
Branch branch4 = new("start python project", python);

// add branches to repo
angular.AddBranch(branch1);
server.AddBranch(branch2);
designPattern.AddBranch(branch3);
python.AddBranch(branch4);

// add repos to user
studentUser.AddRepo(angular);
studentUser.AddRepo(server);
teacherUser.AddRepo(designPattern);
teacherUser.AddRepo(python);

angular.Clone(branch1);

// general files
Folder MainFolder = new("src", 2.6);
Folder components = new("components", 2.3);
Folder services = new("services", 2.2);
Folder utils = new("utils", 2);

Files app = new("app.js", 6.5);
Files index = new("index.js", 5.5);
Files BookList = new("BookList.js", 4.5);
Files BookForm = new("BookForm.js", 2.5);
Files BookDetails = new("BookDetails.js", 3.3);
Files bookService = new("bookService.js", 3.7);
Files formatDate = new("formatDate.js", 3.6);

// folder to branches
branch1.Add(components);
branch2.Add(MainFolder);
branch3.Add(services);
branch4.Add(utils);

// folder to file
MainFolder.Add(components);
MainFolder.Add(services);
MainFolder.Add(utils);
MainFolder.Add(app);
MainFolder.Add(index);
components.Add(BookList);
components.Add(BookForm);
components.Add(BookDetails);
services.Add(bookService);

//func on file/folder
MainFolder.Remove(app);
MainFolder.Remove(app);
MainFolder.Remove(BookList);
Console.WriteLine(MainFolder.ShowDetails(0));
branch2.Add(new Files("new item", 1.2));


//subscribe and sharing
angular.Subscribe(studentUser);
angular.Subscribe(teacherUser);
angular.Unsubscribe(studentUser);
angular.Subscribe(studentUser);
studentUser.Sharing("server project", teacherUser);
server.Subscribe(teacherUser);
Console.WriteLine(branch1.Delete(angular));

//clone
Branch branch5 = server.Clone(branch2);
Branch branch6 = python.Clone(branch4);

//can not move to this state
//app.CurrentState.UnderReveiw(); 

branch5.Add(new Folder("imports", 32.30));

// init task managment
TaskManager taskManager = GeneralCommand.GetInstance();
CommitCommand commitCommand1 = new CommitCommand(index);
DeleteCommand deleteCommand1 = new DeleteCommand(BookDetails, angular);
MergeCommand mergeCommand1 = new MergeCommand(branch1, branch2, angular);
ReviewCommand reviewCommand1 = new ReviewCommand(index);

// activating all commands
taskManager.runTheFunctions(commitCommand1);
taskManager.runTheFunctions(mergeCommand1);
//taskManager.runTheFunctions(reviewCommand1);
taskManager.runTheFunctions(deleteCommand1);
Console.WriteLine("finish!!!!!!!!!");