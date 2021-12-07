using System;
using System.Collections.Generic;

namespace Spectre.Console
{
    /// <summary>
    /// Contains extension methods for <see cref="TextSelectionPrompt{T}"/>.
    /// </summary>
    public static class TextTextSelectionPromptExtensions
    {
        /// <summary>
        /// Sets the selection mode.
        /// </summary>
        /// <typeparam name="T">The prompt result type.</typeparam>
        /// <param name="obj">The prompt.</param>
        /// <param name="mode">The selection mode.</param>
        /// <returns>The same instance so that multiple calls can be chained.</returns>
        public static TextSelectionPrompt<T> Mode<T>(this TextSelectionPrompt<T> obj, SelectionMode mode)
            where T : notnull
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            obj.Mode = mode;
            return obj;
        }

        /// <summary>
        /// Adds multiple choices.
        /// </summary>
        /// <typeparam name="T">The prompt result type.</typeparam>
        /// <param name="obj">The prompt.</param>
        /// <param name="choices">The choices to add.</param>
        /// <returns>The same instance so that multiple calls can be chained.</returns>
        public static TextSelectionPrompt<T> AddChoices<T>(this TextSelectionPrompt<T> obj, params T[] choices)
            where T : notnull
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            foreach (var choice in choices)
            {
                obj.AddChoice(choice);
            }

            return obj;
        }

        /// <summary>
        /// Adds multiple choices.
        /// </summary>
        /// <typeparam name="T">The prompt result type.</typeparam>
        /// <param name="obj">The prompt.</param>
        /// <param name="choices">The choices to add.</param>
        /// <returns>The same instance so that multiple calls can be chained.</returns>
        public static TextSelectionPrompt<T> AddChoices<T>(this TextSelectionPrompt<T> obj, IEnumerable<T> choices)
            where T : notnull
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            foreach (var choice in choices)
            {
                obj.AddChoice(choice);
            }

            return obj;
        }

        /// <summary>
        /// Adds multiple grouped choices.
        /// </summary>
        /// <typeparam name="T">The prompt result type.</typeparam>
        /// <param name="obj">The prompt.</param>
        /// <param name="group">The group.</param>
        /// <param name="choices">The choices to add.</param>
        /// <returns>The same instance so that multiple calls can be chained.</returns>
        public static TextSelectionPrompt<T> AddChoiceGroup<T>(this TextSelectionPrompt<T> obj, T group, IEnumerable<T> choices)
            where T : notnull
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var root = obj.AddChoice(group);
            foreach (var choice in choices)
            {
                root.AddChild(choice);
            }

            return obj;
        }

        /// <summary>
        /// Sets the title.
        /// </summary>
        /// <typeparam name="T">The prompt result type.</typeparam>
        /// <param name="obj">The prompt.</param>
        /// <param name="title">The title markup text.</param>
        /// <returns>The same instance so that multiple calls can be chained.</returns>
        public static TextSelectionPrompt<T> Title<T>(this TextSelectionPrompt<T> obj, string? title)
            where T : notnull
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            obj.Title = title;
            return obj;
        }

        /// <summary>
        /// Sets how many choices that are displayed to the user.
        /// </summary>
        /// <typeparam name="T">The prompt result type.</typeparam>
        /// <param name="obj">The prompt.</param>
        /// <param name="pageSize">The number of choices that are displayed to the user.</param>
        /// <returns>The same instance so that multiple calls can be chained.</returns>
        public static TextSelectionPrompt<T> PageSize<T>(this TextSelectionPrompt<T> obj, int pageSize)
            where T : notnull
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (pageSize <= 2)
            {
                throw new ArgumentException("Page size must be greater or equal to 3.", nameof(pageSize));
            }

            obj.PageSize = pageSize;
            return obj;
        }

        /// <summary>
        /// Sets the highlight style of the selected choice.
        /// </summary>
        /// <typeparam name="T">The prompt result type.</typeparam>
        /// <param name="obj">The prompt.</param>
        /// <param name="highlightStyle">The highlight style of the selected choice.</param>
        /// <returns>The same instance so that multiple calls can be chained.</returns>
        public static TextSelectionPrompt<T> HighlightStyle<T>(this TextSelectionPrompt<T> obj, Style highlightStyle)
            where T : notnull
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            obj.HighlightStyle = highlightStyle;
            return obj;
        }

        /// <summary>
        /// Sets the text that will be displayed if there are more choices to show.
        /// </summary>
        /// <typeparam name="T">The prompt result type.</typeparam>
        /// <param name="obj">The prompt.</param>
        /// <param name="text">The text to display.</param>
        /// <returns>The same instance so that multiple calls can be chained.</returns>
        public static TextSelectionPrompt<T> MoreChoicesText<T>(this TextSelectionPrompt<T> obj, string? text)
            where T : notnull
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            obj.MoreChoicesText = text;
            return obj;
        }

        /// <summary>
        /// Sets the function to create a display string for a given choice.
        /// </summary>
        /// <typeparam name="T">The prompt type.</typeparam>
        /// <param name="obj">The prompt.</param>
        /// <param name="displaySelector">The function to get a display string for a given choice.</param>
        /// <returns>The same instance so that multiple calls can be chained.</returns>
        public static TextSelectionPrompt<T> UseConverter<T>(this TextSelectionPrompt<T> obj, Func<T, string>? displaySelector)
            where T : notnull
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            obj.Converter = displaySelector;
            return obj;
        }
    }
}
