/* 
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
(function () {
    //for non IE modern browser
    if (window.addEventListener) {
        //Function to Scroll all page area by default.
        function pageScrollArea() {
            var body = document.body, element = document.documentElement,
                eleScrollWidth = 0, eleOffsetWidth = 0, bodyScrollWidth = 0, bodyOffsetWidth = 0,
                eleScrollHeight = 0, eleOffsetHeight = 0, bodyScrollHeight = 0, bodyOffsetHeight = 0,
                pageWidth = 0, pageHeight = 0, viewWidth = 0, viewHeight = 0,
                currentTop = 0, currentLeft = 0, scrollWidth = 0, scrollHeight = 0;

            if (element) {
                eleScrollWidth = element.scrollWidth;
                eleOffsetWidth = element.offsetWidth;
                eleScrollHeight = element.scrollHeight;
                eleOffsetHeight = element.offsetHeight;
            }
            if (body) {
                bodyScrollWidth = body.scrollWidth;
                bodyOffsetWidth = body.offsetWidth;
                bodyScrollHeight = body.scrollHeight;
                bodyOffsetHeight = body.offsetHeight;
            }

            // Page actual width and height
            pageWidth = Math.max(eleScrollWidth, eleOffsetWidth, bodyScrollWidth, bodyOffsetWidth);
            pageHeight = Math.max(eleScrollHeight, eleOffsetHeight, bodyScrollHeight, bodyOffsetHeight);

            // Page view area width and height
            viewWidth = window.innerWidth || body.clientWidth || element.clientWidth;
            viewHeight = window.innerHeight || body.clientHeight || element.clientHeight;

            // Current position of the page
            currentTop = (body.scrollTop || element.scrollTop);
            currentLeft = (body.scrollLeft || element.scrollLeft);


            // Consequent loop through Width and Height
            for (scrollWidth = 0; scrollWidth < pageWidth; scrollWidth += viewWidth) {
                scrollTo(scrollWidth, 0);
                for (scrollHeight = 0; scrollHeight < pageHeight; scrollHeight += viewHeight) {
                    scrollBy(0, viewHeight);
                }
            }

            // reset the original position of the page
            scrollTo(currentLeft, currentTop);
        }
        window.addEventListener('load', pageScrollArea, false);
    }
}())

