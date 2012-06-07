﻿/*
 * Copyright (c) 2012 Xbridge Ltd
 * See the file license.txt for copying permission.
 */

using Microsoft.SqlServer.Dts.Runtime;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MongoDataSource;
using MongoDB.Driver;
using Telerik.JustMock;

///<summary>
///This is a test class for MongoConnectionManagerTest and is intended
///to contain all MongoConnectionManagerTest Unit Tests
///</summary>
[TestClass()]
public class MongoConnectionManagerTest {

    ///<summary>
    ///A test for AcquireConnection
    ///</summary>
    [TestMethod()]
    public void AcquireConnectionTest() {
        Assert.Inconclusive("Can't test static calls (with current mocking framework - JustMock), so can't test this method");
    }

    ///<summary>
    ///A test for ReleaseConnection
    ///</summary>
    [TestMethod()]
    public void ReleaseConnectionTest() {
        MongoConnectionManager target = new MongoConnectionManager();

        MongoServer server = Mock.Create<MongoServer>(Constructor.Mocked);

        MongoDatabaseSettings dbSettings = Mock.Create<MongoDatabaseSettings>(Constructor.Mocked);
        MongoDatabase connection = Mock.Create<MongoDatabase>(Constructor.Mocked);

        Mock.Arrange(() => connection.Server).Returns(server);

        target.ReleaseConnection(connection);

        Mock.Assert(() => server.Disconnect());
    }

    ///<summary>
    ///A test for UpdateConnectionString
    ///</summary>
    [TestMethod(), DeploymentItem("MongoSsisDataSource.dll")]
    public void UpdateConnectionStringTest() {
        MongoConnectionManager_Accessor target = new MongoConnectionManager_Accessor();
        target._serverName = "db1";
        target._password = "pass1";
        target._userName = "user1";
        target.UpdateConnectionString();
        Assert.AreEqual(target._connectionString, "mongodb://user1:pass1@db1");
    }

    ///<summary>
    ///A test for Validate
    ///</summary>
    [TestMethod()]
    public void ValidateReturnsSuccessIfServerNameSpecifiedTest() {
        MongoConnectionManager target = new MongoConnectionManager();
        target.ServerName = "server123";
        IDTSInfoEvents infoEvents = null;
        DTSExecResult expected = DTSExecResult.Success;
        DTSExecResult actual = default(DTSExecResult);
        actual = target.Validate(infoEvents);
        Assert.AreEqual(expected, actual);
    }

    ///<summary>
    ///A test for Validate
    ///</summary>
    [TestMethod()]
    public void ValidateReturnsFailureIfServerNameEmptyTest() {
        MongoConnectionManager target = new MongoConnectionManager();
        target.ServerName = "";
        IDTSInfoEvents infoEvents = null;
        DTSExecResult expected = DTSExecResult.Failure;
        DTSExecResult actual = default(DTSExecResult);
        actual = target.Validate(infoEvents);
        Assert.AreEqual(expected, actual);
    }

    ///<summary>
    ///A test for ConnectionString
    ///</summary>
    [TestMethod()]
    public void ConnectionStringTest() {
        MongoConnectionManager target = new MongoConnectionManager();
        string user = "user1";
        string pwd = "pwd1";
        string server = "server1";

        string actual = null;
        target.UserName = user;
        target.Password = pwd;
        target.ServerName = server;
        actual = target.ConnectionString;
        Assert.AreEqual("mongodb://" + user + ":" + pwd + "@" + server, actual);
    }

    ///<summary>
    ///A test for DatabaseName
    ///</summary>
    [TestMethod()]
    public void DatabaseNameTest() {
        MongoConnectionManager target = new MongoConnectionManager();
        string expected = "db1";
        string actual = null;
        target.DatabaseName = expected;
        actual = target.DatabaseName;
        Assert.AreEqual(expected, actual);
    }

    ///<summary>
    ///A test for Password
    ///</summary>
    [TestMethod()]
    public void PasswordTest() {
        MongoConnectionManager target = new MongoConnectionManager();
        string expected = "pwd123";
        string actual = null;
        target.Password = expected;
        actual = target.Password;
        Assert.AreEqual(expected, actual);
    }

    ///<summary>
    ///A test for ServerName
    ///</summary>
    [TestMethod()]
    public void ServerNameTest() {
        MongoConnectionManager target = new MongoConnectionManager();
        string expected = "server123";
        string actual = null;
        target.ServerName = expected;
        actual = target.ServerName;
        Assert.AreEqual(expected, actual);
    }

    ///<summary>
    ///A test for ServerName
    ///</summary>
    [TestMethod()]
    public void ServerNameIsLocalhostByDefaultTest() {
        MongoConnectionManager target = new MongoConnectionManager();
        string actual = null;
        actual = target.ServerName;
        Assert.AreEqual("localhost", actual);
    }

    ///<summary>
    ///A test for UserName
    ///</summary>
    [TestMethod()]
    public void UserNameTest() {
        MongoConnectionManager target = new MongoConnectionManager();
        string expected = "user123";
        string actual = null;
        target.UserName = expected;
        actual = target.UserName;
        Assert.AreEqual(expected, actual);
    }
}