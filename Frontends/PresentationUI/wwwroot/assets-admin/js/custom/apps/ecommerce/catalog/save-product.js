"use strict";

var KTAppEcommerceSaveProduct = function () {
    const initRepeater = () => {
        $("#kt_ecommerce_add_product_options").repeater({
            initEmpty: !1,
            defaultValues: { "text-input": "foo" },
            show: function () {
                $(this).slideDown();
                initializeSelect2();
            },
            hide: function (e) {
                $(this).slideUp(e);
            }
        });
    };

    const initializeSelect2 = () => {
        document.querySelectorAll('[data-kt-ecommerce-catalog-add-product="product_option"]').forEach((element) => {
            if (!$(element).hasClass("select2-hidden-accessible")) {
                $(element).select2({ minimumResultsForSearch: -1 });
            }
        });
    };

    return {
        init: function () {
            const initializeQuillEditors = () => {
                ["#kt_ecommerce_add_product_description", "#kt_ecommerce_add_product_meta_description"].forEach((selector) => {
                    let element = document.querySelector(selector);
                    if (element) {
                        element = new Quill(selector, {
                            modules: {
                                toolbar: [
                                    [{ header: [1, 2, !1] }],
                                    ["bold", "italic", "underline"],
                                    ["image", "code-block"]
                                ]
                            },
                            placeholder: "Type your text here...",
                            theme: "snow"
                        });
                    }
                });
            };

            const initializeTagifyInputs = () => {
                ["#kt_ecommerce_add_product_category", "#kt_ecommerce_add_product_tags"].forEach((selector) => {
                    const element = document.querySelector(selector);
                    if (element) {
                        new Tagify(element, {
                            whitelist: ["new", "trending", "sale", "discounted", "selling fast", "last 10"],
                            dropdown: {
                                maxItems: 20,
                                classname: "tagify__inline__suggestions",
                                enabled: 0,
                                closeOnSelect: !1
                            }
                        });
                    }
                });
            };

            const initializeDropzone = () => {
                new Dropzone("#kt_ecommerce_add_product_media", {
                    url: "https://keenthemes.com/scripts/void.php",
                    paramName: "file",
                    maxFiles: 10,
                    maxFilesize: 10,
                    addRemoveLinks: !0,
                    accept: function (file, done) {
                        if (file.name === "wow.jpg") {
                            done("Naha, you don't.");
                        } else {
                            done();
                        }
                    }
                });
            };

            const initializeAutoOptions = () => {
                const radioButtons = document.querySelectorAll('[name="method"][type="radio"]');
                const autoOptions = document.querySelector('[data-kt-ecommerce-catalog-add-category="auto-options"]');

                radioButtons.forEach((radio) => {
                    radio.addEventListener("change", (event) => {
                        if (event.target.value === "1") {
                            autoOptions.classList.remove("d-none");
                        } else {
                            autoOptions.classList.add("d-none");
                        }
                    });
                });
            };

            initializeQuillEditors();
            initializeTagifyInputs();
            initRepeater();
            initializeDropzone();
            initializeAutoOptions();
        }
    };
}();

KTUtil.onDOMContentLoaded(() => {
    KTAppEcommerceSaveProduct.init();
});
