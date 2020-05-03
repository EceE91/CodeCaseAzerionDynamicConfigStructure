<h1> Code-Case Azerion</h1>
<h3>DynamicConfigStructure</h3>

<strong>Technologies</strong>
<p>
	<ul>
        <li>Visual Studio 2019</li>
        <li>.Net Core MVC version 3.1</li>
        <li>Logger DI</li>
        <li>Swagger</li>
        <li>MongoDB version 4.2.5</li>
        <li>XUnit Test with Moq</li>
        <li>Docker (Docker Toolbox because of my Window 7 OS)</li>
        <li>RabbitMQ</li>
        <li>async / await</li>
        <li>Layered Architecture (Model-DAL-BL/UI)</li>
	<li>CircleCI continious integration</li>
	</ul>
</p>

<p>To reach MongoDB, connectionstring is stored in appsettings.json file & retryWrites is set to true. Retryable writes allow MongoDB drivers to automatically retry certain write operations a single time if they encounter network errors. DatabaseName: "configuration", Collection/Table name: "records" </p>

<p>ApplicationName: The name of the application to run on. (Service-A & Service-B)
ConnectionString: Storage connection information.
RefreshTimerIntervalInMs: Information about how often storage is checked.
</p>

<p>CodeCaseAzerionDynamicConfigStructure.Model project contains Record object to map the data returned from MongoDB</p>

<p>CodeCaseAzerionDynamicConfigStructure.DAL project contains repository.And contains all the required functions to fetch/query/edit the data stored on MongoDB</p>

<p>CodeCaseAzerionDynamicConfigStructure.UI project is the driver project which contains views, controlers</p>

<p>ConfigReader class in ConfiguratorLib project is derived from HostedService class, and it is enabled to fetch the data from storage in a predefined time by the time doing its normal tasks. Async workConfigReader class is derived from HostedService class, and it is enabled to fetch the data from storage in a predefined time by the time doing its normal tasks. Async work</p>
