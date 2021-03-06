﻿/* Copyright © 2020 Lee Kelleher.
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

angular.module("umbraco").controller("Umbraco.Community.Contentment.DataEditors.ConfigurationEditorInline.Controller", [
    "$scope",
    "formHelper",
    function ($scope, formHelper) {

        // console.log("config-editor-inline.model", $scope.model);

        var defaultConfig = {
            editor: {}
        };
        var config = angular.extend({}, defaultConfig, $scope.model.config); // TODO: Replace AngularJS dependency. [LK:2020-03-02]

        var vm = this;

        function init() {

            vm.editor = angular.copy(config.editor); // TODO: Replace AngularJS dependency. [LK:2020-03-02]

            $scope.model.value = $scope.model.value || { type: vm.editor.type, value: vm.editor.defaultValues || {} };

            if ($scope.model.value.type !== vm.editor.type) {
                // TODO: [LK:2020-01-07] What to do if it's a different type?
                console.log("[LK] type is different", $scope.model.value.type, vm.editor.type);

                $scope.model.value.type = vm.editor.type;
            }

            if (vm.editor.fields && vm.editor.fields.length > 0) {
                _.each(vm.editor.fields, function (x) { // TODO: Replace Underscore.js dependency. [LK:2020-03-02]
                    x.alias = x.key;

                    if ($scope.model.value.value.hasOwnProperty(x.key)) {
                        x.value = $scope.model.value.value[x.key];
                    }
                });
            }

            $scope.$on("formSubmitting", function (ev, args) {
                if (vm.editor.fields && vm.editor.fields.length > 0) {
                    _.each(vm.editor.fields, function (x) { // TODO: Replace Underscore.js dependency. [LK:2020-03-02]
                        $scope.model.value.value[x.key] = x.value;
                    });
                }
            });
        };

        init();
    }
]);
