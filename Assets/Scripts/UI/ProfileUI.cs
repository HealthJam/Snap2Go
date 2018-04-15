using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileUI : MonoBehaviour {

    public Button Ingredients;

    public Button Recipes;

    public Button Badges;

    public GameObject ProfileMenu;

    public ListViewer ListViewMenu;

    public BadgeManager badgeManager;

    public RecipeIcon recipePrefab;

    public IngredientIcon ingredientPrefab;

    public List<Recipe> RecipeList;

    public List<Ingredient> IngredientsCollected;

    private void Awake()
    {
        Ingredients.onClick.AddListener(SetupIngredients);
        Recipes.onClick.AddListener(SetupRecipes);
        Badges.onClick.AddListener(SetupBadges);
    }

    private void SetupIngredients()
    {
        List<GameObject> viewingList = new List<GameObject>();

        for (int i = 0; i < IngredientsCollected.Count; i++)
        {
            Ingredient data = IngredientsCollected[i];
            IngredientIcon ingObj = Instantiate(ingredientPrefab) as IngredientIcon;
            ingObj.Initialize(data);
            viewingList.Add(ingObj.gameObject);
        }

        ListViewMenu.AddButtons(viewingList);
        ShowListView("Ingredients");
    }

    private void SetupRecipes()
    {
        List<GameObject> viewingList = new List<GameObject>();

        for (int i = 0; i < RecipeList.Count; i++)
        {
            Recipe data = RecipeList[i];
            data.Init();
            RecipeIcon recipeObj = Instantiate(recipePrefab) as RecipeIcon;
            recipeObj.Initialize(data);
            viewingList.Add(recipeObj.gameObject);
        }

        ListViewMenu.AddButtons(viewingList);
        ShowListView("Recipes");
    }

    private void SetupBadges()
    {
        //List<Badge> badges = badgeManager.getUnlockedBadges();
        List<Badge> badges = badgeManager.GetTestBadges();
        List<GameObject> viewingList = new List<GameObject>();

        for (int i = 0; i < badges.Count; i++)
        {
            Badge b = badges[i];
            BadgeUI badgeObj = Instantiate(badgeManager.badgeUIPrefab) as BadgeUI;
            badgeObj.Initialize(b);
            viewingList.Add(badgeObj.gameObject);
        }

        ListViewMenu.AddButtons(viewingList);
        ShowListView("Badges");
    }

    private void ExitMenu()
    {
        ProfileMenu.gameObject.SetActive(false);
    }

    private void ShowListView(string listName)
    {
        ProfileMenu.gameObject.SetActive(false);
        ListViewMenu.Show();
        ListViewMenu.listName.text = listName;
        ListViewMenu.icon.sprite = Resources.Load<Sprite>("UI/" + listName);
    }

    public void Show()
    {
        ProfileMenu.SetActive(true);
    }

    public void CollectIngredient(Ingredient data)
    {
        if (!IngredientsCollected.Contains(data))
        {
            IngredientsCollected.Add(data);
        }
    }
}
