﻿using Learning_AdvancedCSharpStudies.RecordStudies;

namespace Test_ClassStructures;

public class AccountTests
{
    [Fact]
    public void Test_AccountCreation()
    {
        Guid id = Guid.NewGuid();
        const string name = "Mike Schnobrich";

        Account account = new(id, name);

        account.Id.Should().Be(id);
        account.Name.Should().Be(name);
    }

    [Fact]
    public void Test_AccountCreation_InvalidName_ThrowsException()
    {
        Guid id = Guid.NewGuid();
        const string name = "";

        Action act = () =>
        {
            Account account = new(id, name);
        };

        act.Should().Throw<ArgumentException>()
            .WithMessage("*cannot be an empty string or composed entirely of whitespace*")
            .And.ParamName.Should().Be("name");
    }

    [Fact]
    public void Test_AccountCreation_EmptyGuid_ThrowsException()
    {
        Guid id = Guid.Empty;
        const string name = "Valid Name";

        Action act = () =>
        {
            Account account = new(id, name);
        };

        act.Should().Throw<ArgumentException>()
            .WithMessage("Id cannot be empty*")
            .And.ParamName.Should().Be("id");
    }

    [Fact]
    public void Test_AccountToString()
    {
        Guid id = Guid.NewGuid();
        const string name = "Mike Schnobrich";

        Account account = new(id, name);
        string expectedString = $"Account(Id: {id}, Name: {name})";

        account.ToString().Should().Be(expectedString);
    }
}