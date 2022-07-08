/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    config.skin = 'moonocolor';
    config.filebrowserImageUploadUrl = '/Admin/Home/UploadImage' //Action for Uploding image +
    config.filebrowserUploadUrl = '/Admin/Home/Uploadfile' //Action for Uploding image +
    config.extraAllowedContent = 'iframe[*]'
    config.font_defaultLabel = 'HelveticaNeue';
    config.fontSize_defaultLabel = '14'


    //CKFinder.setupCKEditor(null, '/lib/ckfinder/');

};
