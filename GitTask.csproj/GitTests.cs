using NUnit.Framework;
using System;

namespace GitTask
{
    [TestFixture]
    public class GitTests
    {
        private Git git;

        [Test]
        public void CommitTest_ValidData_RightAnswer_0()
        {
            git = new Git(3); // Начать следить за тремя файлами
            git.Update(0, 5);     // Записать в файл № 0 значение 5
            Assert.True(git.Commit() == 0);         // Закоммитить результат. Вернётся номер коммита — 0.
            git.Update(0, 6);
            Assert.True(git.Checkout(0, 0) == 5);
        }
        [Test]
        public void CommitTest_ValidData_RightAnswer_1()
        {
            git = new Git(10); // Начать следить за тремя файлами
            git.Update(0, 1);
            git.Update(1, 2);
            Assert.True(git.Commit() == 0);         // Закоммитить результат. Вернётся номер коммита — 0.
            git.Update(0, 2);
            Assert.True(git.Commit() == 1);         // Закоммитить результат. Вернётся номер коммита — 0.
            git.Update(0, 6);     // Записать в файл № 0 значение 5
            Assert.True(git.Commit() == 2);         // Закоммитить результат. Вернётся номер коммита — 0.
            Assert.True(git.Checkout(0, 0) == 1);
            Assert.True(git.Checkout(1, 0) == 2);
            Assert.True(git.Checkout(2, 0) == 6);
        }
        [Test]
        public void Checkout_CommitNotExist_ThrowExeption()
        {
            git = new Git(4);
            git.Checkout(0, 0);
            Assert.Fail("no exeption throw");
        }
        [Test]
        public void Checkout_NoUpdate_Commit_ReturnsZero()
        {
            git = new Git(10);
            git.Commit();
            Assert.True(git.Checkout(0, 0) == 0);
        }

    }
}

