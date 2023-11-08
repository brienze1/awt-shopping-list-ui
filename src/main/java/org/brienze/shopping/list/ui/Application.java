package org.brienze.shopping.list.ui;

import org.brienze.shopping.list.ui.view.BaseView;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.builder.SpringApplicationBuilder;
import org.springframework.context.annotation.Bean;

@SpringBootApplication
public class Application {

    public static void main(String[] args) {
        new SpringApplicationBuilder(Application.class).headless(false).run(args);
    }

    @Bean
    public void startScreen() {
        new BaseView().show();
    }

}
