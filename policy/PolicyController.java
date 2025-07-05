package com.example.policy;

import org.springframework.web.bind.annotation.*;
import java.util.*;

@RestController
@RequestMapping("/policy")
public class PolicyController {
    private Map<String, Map<String, Object>> policies = new HashMap<>();

    @PostMapping
    public Map<String, Object> createPolicy(@RequestBody Map<String, Object> policy) {
        String id = UUID.randomUUID().toString();
        policies.put(id, policy);
        return Map.of("policy_id", id, "policy", policy);
    }

    @GetMapping("/{id}")
    public Object getPolicy(@PathVariable String id) {
        Map<String, Object> policy = policies.get(id);
        if (policy == null) {
            return Map.of("error", "Policy not found");
        }
        return Map.of("policy_id", id, "policy", policy);
    }
}