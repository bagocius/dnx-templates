using Xunit;

namespace dnx_templates.lib.classLibrary.Tests {
  public class ProjectInfoTest {

    [Fact]
    public void PassingTest() {
      Assert.Equal(ProjectInfo.Name, "lib.classLibrary");
    }
    
  }
}