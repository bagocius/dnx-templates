using Xunit;

namespace dnx_templates.lib.classLibrary_min.Tests {
  public class ProjectInfoMinTest {

    [Fact]
    public void PassingTest() {
      Assert.Equal(ProjectInfoMin.Name, "lib.classLibrary_min");
    }
    
  }
}