# CSS

CSS (Cascading Style Sheets) is a style sheet language used for describing the presentation and visual styling of HTML and XML documents. It allows web developers to control the appearance, layout, and design of web pages.

[CSS Tutorial](https://developer.mozilla.org/en-US/docs/Learn/CSS), [W3Schools CSS Tutorial](https://www.w3schools.com/css/)\
[CSS Reference](https://developer.mozilla.org/en-US/docs/Web/CSS)\
[CSS Example Code](https://www.w3schools.com/css/css_examples.asp)

> CSS provides a set of rules that define how HTML elements should be displayed. By selecting HTML elements using CSS selectors and applying properties and values to them, you can control aspects such as colors, fonts, spacing, layout, and more.

Here's an example of CSS code that demonstrates how to style HTML elements:

```css
/* EXAMPLE: CSS code to style HTML elements */
body {
  font-family: Arial, sans-serif;
  background-color: #f0f0f0;
}

h1 {
  color: blue;
  font-size: 24px;
}

p {
  color: #333;
  margin-bottom: 10px;
}

a {
  color: red;
  text-decoration: none;
}

.button {
  background-color: yellow;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
}

/* CSS code can be written in a separate CSS file or embedded within <style> tags in an HTML document. */
```

Here are the key aspects and concepts of CSS:

1. **Selectors**: CSS selectors are used to target specific HTML elements or groups of elements that you want to style. Selectors can be based on element names, classes, IDs, attributes, and more.

2. **Properties and Values**: CSS properties define the specific aspect of an element that you want to style, such as color, font, size, padding, margin, and more. Properties are paired with values that specify how the property should be applied.

3. **Inheritance and Cascading**: CSS styles can be inherited from parent elements to their child elements, allowing for consistent styling across a page or website. Additionally, CSS follows a cascading order, where conflicting styles are resolved based on specificity, order of appearance, and the use of important declarations.

4. **Media Queries**: CSS supports media queries, which allow you to apply different styles based on the characteristics of the device or viewport. Media queries enable responsive design by adapting the layout and appearance of a website based on factors such as screen size, resolution, and orientation.

5. **Pseudo-classes and Pseudo-elements**: CSS provides pseudo-classes and pseudo-elements to target elements based on specific conditions or states. Pseudo-classes target elements that are in a particular state or meet specific criteria, such as `:hover`, `:active`, `:first-child`, `:nth-child()`, and more. Pseudo-elements target specific parts of an element, such as `::before` and `::after`.

6. **Selectors and Rule Sets**: CSS rules consist of selectors and declarations. Selectors identify the elements to be styled, and declarations specify the properties and values to be applied to those elements.

CSS is a powerful tool that enables web developers to control the visual aspects of web pages, create appealing designs, and ensure a consistent user experience across different devices and browsers.
