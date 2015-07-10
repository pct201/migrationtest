/* 
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
(function () {
    //for non IE modern browser
    if (window.addEventListener) {
        function loadFn () {
            var currentX = window.pageXOffset, currentY = window.pageYOffset,
            screenWidth =  window.innerWidth, screenHeight = window.innerHeight,
            scrollMaxX = window.scrollMaxX, scrollMaxY = window.scrollMaxY,
            winMaxHeight = scrollMaxY + screenHeight, winMaxWidth = scrollMaxX + screenWidth, x, y;
            if (scrollMaxX > 0 || scrollMaxY > 0) {
                y = 0;
                do{
                    x = 0;
                    do {
                        window.scrollTo(x, y);
                        x += screenWidth;
                    } while (x < winMaxWidth)
                    y += screenHeight;
                } while(y < winMaxHeight)
            }

            //scroll to current position
            window.scrollTo(currentX, currentY);
        }
        window.addEventListener('load', loadFn, false);
    }
}())

