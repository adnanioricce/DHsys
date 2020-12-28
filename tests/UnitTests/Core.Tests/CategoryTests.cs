using Xunit;

namespace Core.Entities.Catalog.Tests
{
    public class CategoryTests
    {        

        [Fact(DisplayName = "category is a parent category of other, the same category can't be added as sub category")]
        public void Given_SetParent_When_receives_a_parent_category_that_is_also_a_sub_category_in_the_receiver_category_Should_expect_a_domain_exception()
        {
            // Given
            var parentCategory = new Category();
            parentCategory.Name = "Parent";
            var subCategory = new Category();
            subCategory.Name = "Sub";
            parentCategory.AddSubCategory(subCategory);
            //When..., Then
            Assert.Throws<DomainException>(() => subCategory.AddSubCategory(parentCategory));
        }

        [Fact(DisplayName = "When add new sub category, the given category should have parent id set to the caller category, if parent category alreadly exists")]
        public void Given_AddSubCategory_When_receives_a_category_Should_set_its_parent_id_and_add_it_to_subcategory_list()
        {
            // Given
            var parentCategory = new Category();
            parentCategory.Name = "Parent";
            parentCategory.Id = 1;
            var subCategory = new Category();
            subCategory.Name = "Sub";

            // When 
            parentCategory.AddSubCategory(subCategory);

            // Then
            Assert.Equal(subCategory.ParentId,parentCategory.Id);
        }
        [Fact(DisplayName = "When add new sub category, if parent category don't exists, should set parent of sub category instead of id")]
        public void Given_AddSubCategory_When_receives_a_category_and_parent_id_is_zero_Then_set_the_parent_of_sub_category_instead_of_its_parent_id()
        {
            // Given
            var parentCategory = new Category();
            parentCategory.Name = "Parent";
            parentCategory.Id = 0;
            var subCategory = new Category();
            subCategory.Name = "Sub";

            // When
            parentCategory.AddSubCategory(subCategory);

            // Then            
            Assert.Equal(subCategory.Parent,parentCategory);

        }
    }
}