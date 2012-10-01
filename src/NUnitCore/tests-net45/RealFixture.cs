using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Core;
using NUnit.Framework;

namespace nunit.core.tests.net45
{
	[Ignore("Run via code")]
	public class RealFixture
	{
		[Test]
		public async void AsyncVoidSuccess()
		{
			var result = await ReturnOne();

			Assert.AreEqual(1, result);
		}

		[Test]
		public async void AsyncVoidFailure()
		{
			var result = await ReturnOne();

			Assert.AreEqual(2, result);
		}

		[Test]
		public async void AsyncVoidError()
		{
			await ThrowException();

			Assert.Fail("Should never get here");
		}

		[Test]
		public async Task AsyncTaskSuccess()
		{
			var result = await ReturnOne();

			Assert.AreEqual(1, result);
		}

		[Test]
		public async Task AsyncTaskFailure()
		{
			var result = await ReturnOne();

			Assert.AreEqual(2, result);
		}

		[Test]
		public async Task AsyncTaskError()
		{
			await ThrowException();

			Assert.Fail("Should never get here");
		}

		[Test]
		public async Task<int> AsyncTaskResultSuccess()
		{
			var result = await ReturnOne();

			Assert.AreEqual(1, result);

			return result;
		}

		[Test]
		public async Task<int> AsyncTaskResultFailure()
		{
			var result = await ReturnOne();

			Assert.AreEqual(2, result);

			return result;
		}

		[Test]
		public async Task<int> AsyncTaskResultError()
		{
			await ThrowException();

			Assert.Fail("Should never get here");

			return 0;
		}

		[TestCase(Result = 1)]
		public async Task<int> AsyncTaskResultCheckSuccess()
		{
			return await ReturnOne();
		}

		[TestCase(Result = 2)]
		public async Task<int> AsyncTaskResultCheckFailure()
		{
			return await ReturnOne();
		}

		[TestCase(Result = 0)]
		public async Task<int> AsyncTaskResultCheckError()
		{
			return await ThrowException();
		}

		[Test]
		[ExpectedException]
		public async void AsyncVoidExpectedException()
		{
			await ThrowException();
		}

		[Test]
		[ExpectedException]
		public async Task AsyncTaskExpectedException()
		{
			await ThrowException();
		}

		[Test]
		[ExpectedException]
		public async Task<int> AsyncTaskResultExpectedException()
		{
			return await ThrowException();
		}

		[Test]
		public async void AsyncVoidAssertSynchrnoizationContext()
		{
			Assert.That(SynchronizationContext.Current, Is.InstanceOf<AsyncSynchronizationContext>());
			await Task.Yield();
		}

		[Test]
		public async void NestedAsyncVoidSuccess()
		{
			var result = await Task.FromResult(await ReturnOne());

			Assert.AreEqual(1, result);
		}

		[Test]
		public async void NestedAsyncVoidFailure()
		{
			var result = await Task.FromResult(await ReturnOne());

			Assert.AreEqual(2, result);
		}

		[Test]
		public async void NestedAsyncVoidError()
		{
			await Task.FromResult(await ThrowException());

			Assert.Fail("Should not get here");
		}

		[Test]
		public async Task NestedAsyncTaskSuccess()
		{
			var result = await Task.FromResult(await ReturnOne());

			Assert.AreEqual(1, result);
		}

		[Test]
		public async Task NestedAsyncTaskFailure()
		{
			var result = await Task.FromResult(await ReturnOne());

			Assert.AreEqual(2, result);
		}

		[Test]
		public async Task NestedAsyncTaskError()
		{
			await Task.FromResult(await ThrowException());

			Assert.Fail("Should never get here");
		}

		[Test]
		public async Task<int> NestedAsyncTaskResultSuccess()
		{
			var result = await Task.FromResult(await ReturnOne());

			Assert.AreEqual(1, result);

			return result;
		}

		[Test]
		public async Task<int> NestedAsyncTaskResultFailure()
		{
			var result = await Task.FromResult(await ReturnOne());

			Assert.AreEqual(2, result);

			return result;
		}

		[Test]
		public async Task<int> NestedAsyncTaskResultError()
		{
			var result = await Task.FromResult(await ThrowException());

			Assert.Fail("Should never get here");

			return result;
		}

		[Test]
		public async void AsyncVoidMultipleSuccess()
		{
			var result = await ReturnOne();

			Assert.AreEqual(await ReturnOne(), result);
		}

		[Test]
		public async void AsyncVoidMultipleFailure()
		{
			var result = await ReturnOne();

			Assert.AreEqual(await ReturnOne() + 1, result);
		}

		[Test]
		public async void AsyncVoidMultipleError()
		{
			var result = await ReturnOne();
			await ThrowException();

			Assert.Fail("Should never get here");
		}

		[Test]
		public async void AsyncTaskMultipleSuccess()
		{
			var result = await ReturnOne();

			Assert.AreEqual(await ReturnOne(), result);
		}

		[Test]
		public async void AsyncTaskMultipleFailure()
		{
			var result = await ReturnOne();

			Assert.AreEqual(await ReturnOne() + 1, result);
		}

		[Test]
		public async void AsyncTaskMultipleError()
		{
			var result = await ReturnOne();
			await ThrowException();

			Assert.Fail("Should never get here");
		}

		private static Task<int> ReturnOne()
		{
			return Task.FromResult(1);
		}

		private static Task<int> ThrowException()
		{
			return Task.Factory.StartNew(() =>
				{
					throw new InvalidOperationException();
					return 1;
				});
		}
	}
}