using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using REST.DataAccess.Entities;

namespace REST.DataAccess.Context;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context =
            new CatalogDbContext(serviceProvider.GetRequiredService<DbContextOptions<CatalogDbContext>>());

        if (context.Items.Any())
            return;

        context.Categories.AddRange(
            new Category
            {
                Id = 1,
                Name = "Math"
            },
            new Category
            {
                Id = 2,
                Name = "Physics"
            },
            new Category
            {
                Id = 3,
                Name = "History"
            },
            new Category
            {
                Id = 4,
                Name = "Geography"
            },
            new Category
            {
                Id = 5,
                Name = "Biology"
            },
            new Category
            {
                Id = 6,
                Name = "Chemistry"
            });

        context.Items.AddRange(
            new Item
            {
                Id = 1,
                CategoryId = 1,
                Title = "Lorem Ipsum",
                Text = "Lorem ipsum dolor sit aot.",
            },
            new Item
            {
                Id = 2,
                CategoryId = 1,
                Title = "Nam vel nulla",
                Text = "Nam vel nulla ac risus viverra auctor in ac sem.",
            },
            new Item
            {
                Id = 3,
                CategoryId = 1,
                Title = "Ipsum elit",
                Text = "Consectetur adipiscing elit, sed do eiusmod tempor.",
            },
            new Item
            {
                Id = 4,
                CategoryId = 2,
                Title = "Vehicula platea pharetra",
                Text = "Vehicula platea pharetra ultrices metus iaculis mi sagittis platea non nam eleifend.",
            },
            new Item
            {
                Id = 5,
                CategoryId = 2,
                Title = "Condimentum ultrices",
                Text = "Condimentum ultrices lectus consequat risus cursus maecenas condimentum facilisi dictumst.",
            },
            new Item
            {
                Id = 6,
                CategoryId = 2,
                Title = "Etiam imperdiet",
                Text = "Etiam imperdiet a consectetur facilisis non amet pellentesque imperdiet cum maecenas.",
            },
            new Item
            {
                Id = 7,
                CategoryId = 3,
                Title = "Et lacinia sit pulvinar",
                Text = "Et lacinia sit pulvinar. Justo cubilia dolor mi massa massa dui quisque enim nunc tellus interdum.",
            },
            new Item
            {
                Id = 8,
                CategoryId = 3,
                Title = "Hac aenean, nisi hendrerit",
                Text = "Hac aenean, nisi hendrerit. Lacus eleifend maecenas in.",
            },
            new Item
            {
                Id = 9,
                CategoryId = 3,
                Title = "Id consectetur purus",
                Text = "Id consectetur purus ut faucibus pulvinar elementum integer.",
            },
            new Item
            {
                Id = 10,
                CategoryId = 4,
                Title = "Integer nec odio",
                Text = "Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.",
            },
            new Item
            {
                Id = 11,
                CategoryId = 4,
                Title = "Nibh vitae",
                Text = "Nibh vitae blandit vel placerat primis primis egestas nam interdum at potenti luctus?",
            },
            new Item
            {
                Id = 12,
                CategoryId = 4,
                Title = "Potenti inceptos",
                Text = "Potenti inceptos vulputate justo habitasse fermentum turpis eu curabitur aliquam fringilla ad.",
            },
            new Item
            {
                Id = 13,
                CategoryId = 5,
                Title = "Etiam commodo",
                Text = "Etiam commodo, leo maecenas purus viverra vitae ac. Scelerisque inceptos lorem eleifend elit.",
            },
            new Item
            {
                Id = 14,
                CategoryId = 5,
                Title = "Praesent libero",
                Text = "Praesent libero. Sed cursus ante dapibus diam. Sed nisi.",
            },
            new Item
            {
                Id = 15,
                CategoryId = 5,
                Title = "Tempus neque",
                Text = "Tempus neque habitant habitant. Donec tempus eget a. Id purus mattis rutrum blandit.",
            },
            new Item
            {
                Id = 16,
                CategoryId = 6,
                Title = "Ut morbi tincidunt",
                Text = "Ut morbi tincidunt augue interdum velit euismod.",
            },
            new Item
            {
                Id = 17,
                CategoryId = 6,
                Title = "Senectus porttitor",
                Text = "Senectus porttitor torquent convallis adipiscing posuere mi odio sagittis ullamcorper nisi.",
            },
            new Item
            {
                Id = 18,
                CategoryId = 6,
                Title = "Pellentesque quam tortor",
                Text = "Pellentesque quam tortor condimentum amet erat a sem. Condimentum accumsan urna dolor?",
            }
        );

        context.SaveChanges();
    }
}